using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess.TextHelpers
{
    public static class TextCnnectorProcessor
    {
        public static string FullFilePath(this string fileName)
        {
            //$HOME\prizemodels.csv
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName}";
        }

        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }
        public static List<TeamModel> ConvertToTeamModels(this List<string> lines)
        {
            List<TeamModel> output = new();

            List<PersonModel> persons = TextConnecter.PeopleFile.FullFilePath().LoadFile().ConvertToModel<PersonModel>();

            //remove header
            if (lines.Any()) 
            {
                lines.RemoveAt(0);
            }

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                TeamModel team = new TeamModel();

                team.Id = int.Parse(cols[0]);
                team.TeamName = cols[1];

                string[] personIds = cols[2].Split('|');

                foreach (string personId in personIds)
                {
                    team.TeamMembers.Add(persons.FirstOrDefault(a => a.Id == int.Parse(personId)) ?? new PersonModel());
                    team.TeamMembersIds += $"{personId}|";
                }
                if (personIds.Any())
                {
                    team.TeamMembersIds = team.TeamMembersIds.Substring(0, team.TeamMembersIds.Length - 1);
                }
                output.Add(team);
            }
            return output;
        }

        public static List<TournamentModel> ConvertToTournamentModels(this List<string> lines)
        {
            List<TournamentModel> output = new();
            List<TeamModel> teams = TextConnecter.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();
            List<PrizeModel> prizes = TextConnecter.PrizesFile.FullFilePath().LoadFile().ConvertToModel<PrizeModel>();
            List<MatchupModel> matchups = TextConnecter.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();

            foreach (string line in lines)
            {
                TournamentModel tournament = new TournamentModel();
                string[] cols = line.Split(",");
                tournament.Id = int.Parse(cols[0]);
                tournament.TournamentName = cols[1];
                tournament.EntryFee = decimal.Parse(cols[2]);

                string[] teamIds = cols[3].Split('|');

                foreach (var id in teamIds)
                {
                    tournament.EnteredTeams.Add(teams.FirstOrDefault(a => a.Id == int.Parse(id)));
                }

                string[] prizeIds = cols[4].Split('|');
                foreach (var id in prizeIds)
                {
                    tournament.Prizes.Add(prizes.FirstOrDefault(a => a.Id == int.Parse(id)));
                }

                // Capture round Information
                string[] rounds = cols[5].Split('|');

                foreach (string round in rounds)
                {
                    string[] msText = round.Split('^');
                    List<MatchupModel> ms = new List<MatchupModel>();

                    foreach (string id in msText)
                    {
                        ms.Add(matchups.Where(x=>x.Id == int.Parse(id)).First());
                    }
                    tournament.Rounds.Add(ms);
                }

                output.Add(tournament);
            }
            return output;
        }

        public static List<T> ConvertToModel<T>(this List<string> lines) where T : class, new()
        {
            List<T> output = new();

            if (!lines.Any())
            {
                return output;
            }

            var header = lines[0].Split(",");

            lines.RemoveAt(0);

            foreach (string line in lines)
            {
                string[] cols = line.Split(",");

                T newObject = new();

                var properties = newObject.GetType().GetProperties().ToList();

                properties.RemoveAll(a => !a.CanWrite);

                for (int i = 0; i < header.Length; i++)
                {
                    foreach (var property in properties)
                    {
                        if (property.Name == header[i])
                        {
                            //if (property.Name.EndsWith("Properties"))
                            //{
                            //    var listProp = properties.FirstOrDefault(a => a.Name.Equals(property.Name.Replace("Properties", "")) && a.GetType().Equals(typeof(IList)));


                            //    var className = listProp?.GetType().GetGenericArguments()[0];

                            //    var fileName = className?.Name + ".csv";

                            //    MethodInfo? createMethod = typeof(TextCnnectorProcessor).GetMethod("ConvertToModel")?.MakeGenericMethod(className);

                            //    Type ListC = typeof(List<>).MakeGenericType(className);

                            //    var result = createMethod?.Invoke(null, new object[] { fileName.FullFilePath().LoadFile() }) as IList;

                            //    Convert.ChangeType(result, ListC);
                            //}
                            property.SetValue(newObject, Convert.ChangeType(cols[i], property.PropertyType));
                        }
                    }
                }
                output.Add(newObject);
            }
            return output;
        }



        public static void SaveToFile<T>(this List<T> models, string fileName) where T : class, new()
        {
            List<string> lines = new();

            if (!models.Any() || string.IsNullOrEmpty(fileName))
            {
                return;
            }

            List<PropertyInfo> prop = models[0].GetType().GetProperties().ToList();

            prop.RemoveAll(a => !(a.PropertyType.IsPrimitive || a.PropertyType.Equals(typeof(string))));

            StringBuilder header = new();
            foreach (var item in prop)
            {
                header.Append(item.Name);
                header.Append(',');
            }

            lines.Add(header.ToString().Substring(0, header.Length - 1));

            foreach (var item in models)
            {
                StringBuilder line = new();
                foreach (var p in prop)
                {
                    line.Append(p.GetValue(item)?.ToString());
                    line.Append(',');

                }

                lines.Add(line.ToString().Substring(0, line.Length - 1));
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SaveToTournamentFile(this List<TournamentModel> models)
        {
            List<string> lines = new();

            foreach (TournamentModel tournament in models)
            {
                lines.Add($@"{tournament.Id},
                    {tournament.TournamentName},
                    {tournament.EntryFee},
                    {ConverTeamListToString(tournament.EnteredTeams)},
                    {ConverPrizeListToString(tournament.Prizes)},
                    {ConverRoundsListToString(tournament.Rounds)}
                    ");
            }

            File.WriteAllLines(TextConnecter.TournamentFile.FullFilePath(), lines);

        }

        public static void SaveRoundsToFile(this TournamentModel model, string MatchupFile, string MatchupEntryFile)
        {
            foreach (List<MatchupModel> round in model.Rounds)
            {
                foreach (MatchupModel matchup in round)
                {
                    matchup.SaveMatchupToFile(MatchupEntryFile, MatchupEntryFile);
                }
            }
        }
        private static List<MatchupEntryModel> ConvertStringToMathupEntryModel(string input)
        {
            string[] ids = input.Split('|');
            List<MatchupEntryModel> output = new List<MatchupEntryModel>();

            List<MatchupEntryModel> models = TextConnecter.MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();
            foreach (string id in ids)
            {
                output.Add(models.FirstOrDefault(a => a.Id == int.Parse(id)));
            }

            return output;
        }
        public static List<MatchupEntryModel> ConvertToMatchupEntryModels(this List<string> input)
        {
            List<MatchupEntryModel> output = new();
            foreach (string line in input)
            {
                string[] cols = line.Split(',');
                MatchupEntryModel model = new MatchupEntryModel();
                model.Id = int.Parse(cols[0]);
                if (cols[1].Length == 0)
                {
                    model.TeamCompeting = null;
                }
                else 
                {
                    model.TeamCompeting = LookupTeamById(int.Parse(cols[1]));
                }

                model.Score = Double.Parse(cols[2]);
                if (int.TryParse(cols[2], out int parentId))
                {
                    model.ParentMatchup = LookupMatchupById(parentId);
                }
                else
                {
                    model.ParentMatchup = null;
                }
                output.Add(model);
            }
            return output;
        }
        private static MatchupModel LookupMatchupById(int id)
        {
            return TextConnecter.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels().FirstOrDefault(x => x.Id == id) ?? new MatchupModel();
        }

        private static TeamModel LookupTeamById(int id)
        {
            return TextConnecter.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels().FirstOrDefault(a => a.Id == id) ?? new TeamModel();
        }
        public static List<MatchupModel> ConvertToMatchupModels(this List<string> lines)
        {

            List<MatchupModel> output = new List<MatchupModel>();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                MatchupModel matchup = new MatchupModel();
                matchup.Id = int.Parse(cols[0]);
                matchup.Enteries = ConvertStringToMathupEntryModel(cols[1]);
                matchup.Winner = LookupTeamById(int.Parse(cols[2]));
                matchup.MatchupRound = int.Parse(cols[3]);
                output.Add(matchup);
            }
            return output;
        }
        public static void SaveMatchupToFile(this MatchupModel matchup, string mathupFile, string mathupEntryFile)
        {

            List<MatchupModel> matchups = TextConnecter.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();

            int id = 0;

            if (matchups.Any())
            {
                id = matchups.OrderByDescending(x => x.Id).First().Id + 1;
            }

            matchup.Id = id;
            matchups.Add(matchup);

            //save mathup file
            List<string> lines = new List<string>();

            foreach (MatchupModel m in matchups)
            {
                string winner = "";
                if (matchup.Winner != null)
                {
                    winner = m.Winner.Id.ToString();
                }
                lines.Add($"{m.Id},{m.Enteries},{""},{winner},{m.MatchupRound}");
            }

            File.WriteAllLines(TextConnecter.MatchupFile.FullFilePath(), lines);

            foreach (MatchupEntryModel matchupEntry in matchup.Enteries)
            {
                matchupEntry.SaveEntryToFile(mathupEntryFile);
            }

            //save mathup file
            lines = new List<string>();

            foreach (MatchupModel m in matchups)
            {
                string winner = "";
                if (matchup.Winner != null)
                {
                    winner = m.Winner.Id.ToString();
                }
                lines.Add($"{m.Id},{m.Enteries},{ConvertEntriesListToString(m.Enteries)},{winner},{m.MatchupRound}");
            }

            File.WriteAllLines(TextConnecter.MatchupFile.FullFilePath(), lines);
        }
        private static string ConvertEntriesListToString(List<MatchupEntryModel> entries)
        {
            string output = "";

            if (!entries.Any())
            {
                return "";
            }

            foreach (MatchupEntryModel entry in entries)
            {
                output += $"{entry.Id}^";
            }

            return output.Substring(0, output.Length - 1);
        }


        public static void SaveEntryToFile(this MatchupEntryModel matchupEntry, string matchupEntryFile)
        {
            List<MatchupEntryModel> entries = TextConnecter.MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();

            int id = 0;
            if (entries.Any())
            {
                id = entries.OrderByDescending(x => x.Id).First().Id + 1;
            }
            matchupEntry.Id = id;
            entries.Add(matchupEntry);

            List<string> lines = new List<string>();

            foreach (MatchupEntryModel entry in entries)
            {
                string parent = "";
                if (entry.ParentMatchup != null)
                {
                    parent = entry.ParentMatchup.Id.ToString();
                }
                string teamCompeting = string.Empty;
                if (entry.TeamCompeting != null) 
                {
                    teamCompeting = entry.TeamCompeting.Id.ToString();
                }
                lines.Add($"{entry.Id},{teamCompeting},{entry.Score},{parent}");
            }

            File.WriteAllLines(TextConnecter.MatchupEntryFile.FullFilePath(), lines);
        }
        private static string ConverRoundsListToString(List<List<MatchupModel>> rounds)
        {
            string output = "";

            if (!rounds.Any())
            {
                return "";
            }

            foreach (List<MatchupModel> mathups in rounds)
            {
                output += $"{ConverMatchupListToString(mathups)}|";
            }

            return output.Substring(0, output.Length - 1);
        }

        private static string ConverMatchupListToString(List<MatchupModel> mathups)
        {
            string output = "";

            if (!mathups.Any())
            {
                return "";
            }

            foreach (MatchupModel mathup in mathups)
            {
                output += $"{mathup.Id}^";
            }

            return output.Substring(0, output.Length - 1);
        }

        private static string ConverPrizeListToString(List<PrizeModel> prizes)
        {
            string output = "";

            if (!prizes.Any())
            {
                return "";
            }

            foreach (PrizeModel prize in prizes)
            {
                output += $"{prize.Id}|";
            }

            return output.Substring(0, output.Length - 1);
        }
        private static string ConverTeamListToString(List<TeamModel> teams)
        {
            string output = "";

            if (!teams.Any())
            {
                return "";
            }

            foreach (TeamModel team in teams)
            {
                output += $"{team.Id}|";
            }

            return output.Substring(0, output.Length - 1);
        }
    }
}
