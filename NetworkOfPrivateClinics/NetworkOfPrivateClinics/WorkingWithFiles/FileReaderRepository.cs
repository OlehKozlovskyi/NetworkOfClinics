using NetworkOfPrivateClinics.BisinessLogic;
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
        public List<Clinic> ReadFromSourceFile()
        {
            FileReader reader = new FileReader();
            return reader.Read(_pathToSourceFile, new JsonFileReader());
        }
    }
}
