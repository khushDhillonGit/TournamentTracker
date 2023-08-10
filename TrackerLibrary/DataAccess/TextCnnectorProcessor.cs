using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
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
        public static List<TeamModel> ConvertToTeamModels(this List<string> lines,string peopleFileName)
        {
            List<TeamModel> output = new();

            List<PersonModel> persons = peopleFileName.FullFilePath().LoadFile().ConvertToModel<PersonModel>();

            //remove header
            lines.RemoveAt(0);

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
            foreach (string line in lines)
            {
                TournamentModel tournament = new TournamentModel();
                string[] cols = line.Split(",");
                tournament.Id = int.Parse(cols[0]);
                tournament.TournamentName = cols[1];
                tournament.EntryFee = decimal.Parse(cols[2]);

                string[] teamIds = cols[3].Split('|');

                List<TeamModel> teams = TextConnecter.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels(TextConnecter.PeopleFile);
                List<PrizeModel> prizes = TextConnecter.PrizesFile.FullFilePath().LoadFile().ConvertToModel<PrizeModel>();
                foreach (var id in teamIds) 
                {
                    tournament.EnteredTeams.Add(teams.FirstOrDefault(a => a.Id == int.Parse(id)));
                }

                string[] prizeIds = cols[4].Split('|');
                foreach (var id in prizeIds) 
                {
                    tournament.Prizes.Add(prizes.FirstOrDefault(a => a.Id == int.Parse(id)));
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
                            if (property.Name.EndsWith("Properties"))
                            {
                                var listProp = properties.FirstOrDefault(a => a.Name.Equals(property.Name.Replace("Properties", "")) && a.GetType().Equals(typeof(IList)));


                                var className = listProp?.GetType().GetGenericArguments()[0];

                                var fileName = className?.Name + ".csv";

                                MethodInfo? createMethod = typeof(TextCnnectorProcessor).GetMethod("ConvertToModel")?.MakeGenericMethod(className);

                                Type ListC = typeof(List<>).MakeGenericType(className);

                                var result = createMethod?.Invoke(null, new object[] { fileName.FullFilePath().LoadFile() }) as IList;

                                Convert.ChangeType(result, ListC);
                            }
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

    }
}
