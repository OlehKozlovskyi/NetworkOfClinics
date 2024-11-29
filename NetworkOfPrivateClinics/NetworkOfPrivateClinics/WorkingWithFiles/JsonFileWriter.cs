using NetworkOfPrivateClinics.BisinessLogic;
using NetworkOfPrivateClinics.CustomExceptions;
using NetworkOfPrivateClinics.Interfaces;
using Newtonsoft.Json;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public class JsonFileWriter :IFileWriter
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

        public async Task Write(List<Clinic> clinicsList)
        {
            string jsonData = JsonConvert.SerializeObject(clinicsList, Formatting.Indented);
            await File.WriteAllTextAsync(FilePath, jsonData);
        }
    }
}
