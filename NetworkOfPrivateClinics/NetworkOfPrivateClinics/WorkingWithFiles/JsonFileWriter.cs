using NetworkOfPrivateClinics.BisinessLogic;
using NetworkOfPrivateClinics.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public class JsonFileWriter : IFileWriter
    {
        public JsonFileWriter(FullPathCreator fullPathCreator)
        {
            FullPath = fullPathCreator.GetFullPath();
        }

        public Path FullPath { get; }

        public void Write(List<Clinic> clinicsList)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(FullPath))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, clinicsList);
                }
            }
            
        }
    }
}
