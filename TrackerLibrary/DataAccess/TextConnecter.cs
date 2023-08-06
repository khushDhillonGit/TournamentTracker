using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;
using System.Runtime.InteropServices;
using System.Net;

namespace TrackerLibrary.DataAccess
{
    public class TextConnecter : IDataConection
    {
        private const string PrizesFile = nameof(PrizeModel) + ".csv";
        private const string PeopleFile = nameof(PersonModel) + ".csv";
        private const string TeamFile = nameof(TeamModel) + ".csv";

        public T CreateObject<T>(string fileName, T model) where T : class , IFields, new()
        {
            List<T> output = new();
  
            output = fileName.FullFilePath().LoadFile().ConvertToModel<T>();

            int id = 0;

            if (output.Any()) { 
                id = output.OrderByDescending(a=>a.Id).First().Id + 1;
            }

            model.Id = id;

            output.Add(model);

            output.SaveToFile(fileName);

            return model;

        }

        public PrizeModel CreatePrize(PrizeModel model)
        {
            return CreateObject(PrizesFile, model);
        }

        public PersonModel CreatePerson(PersonModel model)
        {
            return CreateObject(PeopleFile, model);
        }

        public List<PersonModel> GetPerson_All()
        {
            return PeopleFile.FullFilePath().LoadFile().ConvertToModel<PersonModel>();
        }

        public TeamModel CreateTeam(TeamModel model)
        {

            List<TeamModel> teams = TeamFile.FullFilePath().LoadFile().ConvertToTeamModels(PeopleFile);

            int id = 0;

            if (teams.Any())
            {
                id = teams.OrderByDescending(a => a.Id).First().Id + 1;
            }

            model.Id = id;
            teams.Add(model);
            teams.SaveToFile<TeamModel>(TeamFile);

            return model;
            //StringBuilder stringBuilder = new StringBuilder();

            //foreach (PersonModel person in model.TeamMembers) 
            //{
            //    stringBuilder.Append($"[Id:{person.Id},{person.FullName}]");
            //    stringBuilder.Append('|');
            //}

            //model.TeamMembersProperties = stringBuilder.ToString().Substring(0,stringBuilder.Length -1);

            //model = CreateObject<TeamModel>(TeamFile,model);

            //return model;

        }
    }
}
