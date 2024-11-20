using NetworkOfPrivateClinics.BisinessLogic;
using NetworkOfPrivateClinics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    //Refactore it maybe can be removed
    public class FileReader
    {
        public List<Clinic> Read(string path)
        {
            IFileReader reader = GetFileReader(path);
            return reader.Read(path);
        }

        private IFileReader GetFileReader(string path)
        {
            string fileExtensionFromPath = Path.GetExtension(path);
            if (fileExtensionFromPath == ".csv")
                return new CsvFileReader();
            if (fileExtensionFromPath == ".json")
                return new JsonFileReader();
            throw new InvalidOperationException();
        }
    }
}
