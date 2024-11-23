using NetworkOfPrivateClinics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkOfPrivateClinics.CustomExceptions;
using NetworkOfPrivateClinics.BisinessLogic;
using Newtonsoft.Json;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public class JsonFileReader : IFileReader
    {
        //private JsonSerializerOptions _options;

        //public JsonFileReader() 
        //{
        //    _options = new JsonSerializerOptions()
        //    {
        //        IncludeFields = true,
        //        PropertyNameCaseInsensitive = true,
        //        WriteIndented = true,
        //        PropertyNamingPolicy = new PascalCasePolicy()
        //    };
        //}

        public async Task<List<Clinic>> Read(string path)
        {
            List<Clinic> items = new();
            try
            {
                using (StreamReader stream = File.OpenText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    items = (List<Clinic>)serializer.Deserialize(stream, typeof(List<Clinic>));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);
            }
             return items;
        }
    }
}
