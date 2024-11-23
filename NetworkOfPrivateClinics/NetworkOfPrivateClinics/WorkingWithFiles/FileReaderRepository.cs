using NetworkOfPrivateClinics.BisinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkOfPrivateClinics.CustomExceptions;
using System.Net;

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
        public async Task<List<Clinic>> ReadFromSourceFile()
        {
            FileReader reader = new FileReader();
            return await reader.Read(_pathToSourceFile, new JsonFileReader());
        }
    }
}
