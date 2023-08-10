
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using System.Data.SqlClient;
using Dapper;
using System.Reflection;
using System.Drawing;

namespace TrackerLibrary.DataAccess
{
    public class SqlConnecter : IDataConection
    {
        private const string db = "Tournaments";
        /// <summary>
        ///  Saves a new Prize
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The Prize information</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {

            using (IDbConnection connection = new SqlConnection(GlobalConfig.CnnString(db))) 
            {
                var p = new DynamicParameters();
                p.Add("@PlaceNumber",model.PlaceNumber);
                p.Add("@PlaceName",model.PlaceName);
                p.Add("@PrizePercentage",model.PrizePercentage);
                p.Add("@PrizeAmount",model.PrizeAmount);
                p.Add("@id", 0, dbType: DbType.Int32,direction: ParameterDirection.Output);

                connection.Execute("dbo.spPrizes_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                return model;
            }
                
        }

        public PersonModel CreatePerson(PersonModel model) 
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@FirstName", model.FirstName);
                p.Add("@LastName", model.LastName);
                p.Add("@EmailAddress", model.EmailAddress);
                p.Add("@CellphoneNumber", model.CellPhoneNumber);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPeople_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                return model;
            }
        }

        public TeamModel CreateTeam(TeamModel model)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.CnnString(db))) 
            {
                DynamicParameters teamParameters = new DynamicParameters();
                teamParameters.Add("@TeamName", model.TeamName);
                teamParameters.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTeams_Insert", teamParameters, commandType: CommandType.StoredProcedure);

                model.Id = teamParameters.Get<int>("@id");

                foreach (PersonModel teamMember in model.TeamMembers)
                {
                    teamParameters = new DynamicParameters();
                    teamParameters.Add("@TeamId", model.Id);
                    teamParameters.Add("@PersonId", teamMember.Id);

                    connection.Execute("dbo.spTeamMembers_Insert", teamParameters, commandType: CommandType.StoredProcedure);
                }

                return model;
            }
        }


        public List<PersonModel> GetPerson_All()
        {
            List<PersonModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                output = connection.Query<PersonModel>("dbo.spPeople_GetAll").ToList();
            }
            return output;
        }

        public List<TeamModel> GetTeam_All()
        {
            List<TeamModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                output = connection.Query<TeamModel>("dbo.spTeam_GetAll").ToList();

                foreach (TeamModel team in output) 
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@TeamId", team.Id);

                    team.TeamMembers = connection.Query<PersonModel>("dbo.spTeamMembers_GetByTeam",parameter,commandType:CommandType.StoredProcedure).ToList();
                }
            }
            return output;
        }

        public TournamentModel CreateTournament(TournamentModel model)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.CnnString(db)))
            {
                SaveTournament(model, connection);
                SaveTournamentPrize(model, connection);
                SaveTournamentEntries(model, connection);

                return model;
            }
        }

        private static void SaveTournamentEntries(TournamentModel model, IDbConnection connection)
        {
            foreach (TeamModel team in model.EnteredTeams)
            {
                var teamDP = new DynamicParameters();
                teamDP.Add("@TeamId", team.Id);
                teamDP.Add("@TournamentId", model.Id);
                teamDP.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTournamentTeams_Insert", teamDP, commandType: CommandType.StoredProcedure);
            }
        }

        private void SaveTournamentPrize(TournamentModel model, IDbConnection connection)
        {
            foreach (PrizeModel prize in model.Prizes)
            {
                var prizeDP = new DynamicParameters();
                prizeDP.Add("@PrizeId", prize.Id);
                prizeDP.Add("@TournamentId", model.Id);
                prizeDP.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTournamentPrizes_Insert", prizeDP, commandType: CommandType.StoredProcedure);
            }
        }

        private void SaveTournament(TournamentModel model, IDbConnection connection)
        {
            var p = new DynamicParameters();
            p.Add("@EntryFee", model.EntryFee);
            p.Add("@TournamentName", model.TournamentName);
            p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("dbo.spTournaments_Insert", p, commandType: CommandType.StoredProcedure);

            model.Id = p.Get<int>("@id");
        }
    }
}
