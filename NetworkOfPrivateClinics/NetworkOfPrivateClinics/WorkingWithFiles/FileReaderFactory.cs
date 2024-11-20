using NetworkOfPrivateClinics.CustomExceptions;
using NetworkOfPrivateClinics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public class FileReaderFactory
    {
        private string _path;

        public FileReaderFactory(string fullPath) 
        {
            FullPath = fullPath;
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

        private IFileReader GetFileReader()
        {
            string fileExtensionFromPath = Path.GetExtension(_path);
            if (fileExtensionFromPath == ".json")
                return new JsonFileReader();
            throw new InvalidOperationException();
        }
    }
}
