using NetworkOfPrivateClinics.BisinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public class FileReaderRepository
    {
        private string _pathToSourceFile;

        public FileReaderRepository() 
        {
            _pathToSourceFile = Path.GetFullPath("clinics_source.json");
        }
        
        public List<Clinic> ReadDefaultSourceFile()
        {
            FileReader reader = new FileReader();
            return reader.Read(_pathToSourceFile, new JsonFileReader());
        }

        public List<Clinic> ReadUsersSourceFile(string path)
        {
            FileReader reader = new FileReader();
            return reader.Read(path, new JsonFileReader());
        }
    }
}
