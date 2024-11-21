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
        public async Task<List<Clinic>> Read(string path)
        {
            List<Clinic> items = new();
            try
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = await r.ReadToEndAsync();
                    items = JsonConvert.DeserializeObject<List<Clinic>>(json);
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
