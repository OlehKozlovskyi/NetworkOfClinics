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
        private FilePathValidator _validator;
        private string _path;

        public JsonFileReader(string path, FilePathValidator validator) 
        {
            _validator = validator;
            Path = path;
        }

        public string Path
        {
            get => _path;
            set
            {
                if (!_validator.ValidateDirectory(value))
                    throw new InvalidDirectoryException(value);
                _path = value;
            }
        } 

        public List<Clinic> Read(string path)
        {
            List<Clinic> items = new();
            using (StreamReader r = new StreamReader("file.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Clinic>>(json);
            }
            return items;
        }
    }
}
