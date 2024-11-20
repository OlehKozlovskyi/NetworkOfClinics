using NetworkOfPrivateClinics.CustomExceptions;
using NetworkOfPrivateClinics.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public class FilePath
    {
        private string _path;
        private readonly IExtension _fileExtension;

        public FilePath(IExtension filesExtension)
        {
            Path = Directory.GetCurrentDirectory();
            _fileExtension = filesExtension;
        }

        public FilePath(string path, IExtension filesExtension)
        {
            _fileExtension = filesExtension;
            Path = path;
        }

        public string Path
        {
            get => _path;
            private set
            {
                if (Directory.Exists(value))
                    throw new InvalidDirectoryException(value);
                _path = value;
            }
        }

        public string[] GetPaths()
        {
            string[] paths = Directory.GetFiles(Path, _fileExtension.Extension);
            if (paths.Length == 0)
                throw new NotFoundPathsToSupportedFilesException(paths);
            return paths;
        }
    }
}
