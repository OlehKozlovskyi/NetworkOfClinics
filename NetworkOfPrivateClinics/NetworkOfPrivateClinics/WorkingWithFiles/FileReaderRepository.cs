using NetworkOfPrivateClinics.BusinessLogic;
using NetworkOfPrivateClinics.CustomExceptions;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public class FileReaderRepository
    {
        private string _pathToSourceFile;

        public FileReaderRepository(string path) 
        {
            PathToSourceFile = path;
        }

        public string PathToSourceFile
        {
            get => _pathToSourceFile;
            set
            {
                if (Path.GetExtension(value) != ".json")
                    throw new InvalidFileExtension(Path.GetFileName(value));
                _pathToSourceFile = value;
            }
        }

        public void ChangeSourcePath(string path) => PathToSourceFile = path;

        public async Task<List<Clinic>> ReadFromSourceFile()
        {
            FileReader reader = new FileReader();
            return await reader.Read(_pathToSourceFile, new JsonFileReader());
        }
    }
}
