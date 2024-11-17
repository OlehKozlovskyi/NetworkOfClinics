using NetworkOfPrivateClinics.BisinessLogic;
using NetworkOfPrivateClinics.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics
{
    public class CustomJsonWriter : IWriter
    {
        private string _fileName;
        private string _path;
        private readonly string _fullPath;

        public CustomJsonWriter(string path, string fileName)
        {
            Path = path;
            _fileName = fileName;
            _fullPath = String.Join('\\', Path, _fileName);
        }

        public string FileName
        {
            get=>_fileName;
            private set
            {
                if (value is null)
                    throw new ArgumentNullException(nameof(value));
                _fileName = value;
            }
        }

        public string Path 
        {
            get => _path;
            private set
            {
                if(value is null)
                    throw new ArgumentNullException(nameof(value));
                _path = value;
            }
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Write(params ClinicRepository[] clinicsList)
        {
            JsonSerializer serializer = new JsonSerializer();
            using(StreamWriter sw = new StreamWriter(_fullPath))
            using(JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, clinicsList);
            }
        }
    }
}
