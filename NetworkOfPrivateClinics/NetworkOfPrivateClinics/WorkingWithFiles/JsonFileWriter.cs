using NetworkOfPrivateClinics.BisinessLogic;
using NetworkOfPrivateClinics.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkOfPrivateClinics.CustomExceptions;
using Newtonsoft.Json;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public class JsonFileWriter : BaseWriter
    {
        private string _path;
        //private JsonSerializerOptions _options;

        public JsonFileWriter(string path)
        {
            FullPath = path;
            //_options = new JsonSerializerOptions()
            //{
            //    IncludeFields = true,
            //    PropertyNameCaseInsensitive = true,
            //    WriteIndented = true,
            //    PropertyNamingPolicy = new PascalCasePolicy(),
            //};
        }

        public string FullPath 
        {
            get => _path;
            private set
            {
                if (!Path.HasExtension(value))
                    throw new InvalidDirectoryException(value);
                _path = value;
            }
        }

        public override async void Write(List<Clinic> clinicsList)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter streamWriter = new StreamWriter(FullPath))
            {
                using (JsonWriter writer = new JsonTextWriter(streamWriter))
                {
                    serializer.Serialize(writer, clinicsList);
                }
            }
            
        }
    }
}
