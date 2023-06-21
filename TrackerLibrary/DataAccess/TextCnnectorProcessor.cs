using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
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

        public static List<T> ConvertToModel<T>(this List<string> lines) where T : class, new()
        {
            List<T> output = new();

            if (!lines.Any()) { 
                return output;
            }
            var header = lines[0].Split(",");

            lines.RemoveAt(0);

            foreach (string line in lines)
            {
                string[] cols = line.Split(",");

                T newObject = new();

                var properties = newObject.GetType().GetProperties();

                for (int i = 0; i < header.Length; i++)
                {

                    foreach (var property in properties)
                    {
                        if (property.Name == header[i])
                        {
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

            var prop = models[0].GetType().GetProperties();

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
