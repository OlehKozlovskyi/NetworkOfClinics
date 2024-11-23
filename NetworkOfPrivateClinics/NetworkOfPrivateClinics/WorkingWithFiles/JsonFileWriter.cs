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

        public JsonFileWriter(string path)
        {
            FilePath = path;
        }

        public string FilePath 
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
            string json = JsonConvert.SerializeObject(clinicsList, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }
    }
}
