using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;
using System.Runtime.InteropServices;

namespace TrackerLibrary.DataAccess
{
    public class TextConnecter : IDataConection
    {
        private const string PrizesFile = "PrizeModels.csv";
        private const string PeopleFile = "PeopleModels.csv";

        public T CreateObject<T>(string fileName, T model) where T : class , IFields, new()
        {
            List<T> output = new();

            var prop = model.GetType().GetProperties();
           
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
    }
}
