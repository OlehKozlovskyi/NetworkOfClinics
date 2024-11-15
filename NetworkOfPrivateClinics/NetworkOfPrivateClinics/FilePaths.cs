using NetworkOfPrivateClinics.CustomExceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics
{
    // Violate solid open/closed principe, should be replaced by classes

    public enum SupportedFileFormats
    {
        json,
        csv
    }

    public class FilePaths
    {
        private string _path;
        private readonly FilePathsValidator _directoryValidator;
        private readonly SupportedFileFormats _fileFormat;

        public FilePaths(SupportedFileFormats fileFormat) 
        {
            Path = Directory.GetCurrentDirectory();
            _fileFormat = fileFormat;
        }

        public FilePaths(string path, FilePathsValidator pathsValidator, SupportedFileFormats fileFormat)
        {
            _directoryValidator = pathsValidator;
            _fileFormat = fileFormat;
            Path = path;
        }

        public string Path
        {
            get => _path;
            private set
            {
                if (!_directoryValidator.ValidateDirectory(value))
                    throw new InvalidDirectoryException(value);
                _path = value;
            }
        }

        public string[] GetPaths()
        {
            string[] paths = Directory.GetFiles(Path, Enum.GetName(_fileFormat));
            if (paths.Length == 0)
                throw new NotFoundPathsToSupportedFilesException(paths);
            return paths;
        }
    }
}
