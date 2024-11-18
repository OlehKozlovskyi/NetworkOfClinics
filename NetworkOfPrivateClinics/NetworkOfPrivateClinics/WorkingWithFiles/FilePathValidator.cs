using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public class FilePathValidator
    {
        public bool ValidateDirectory(string path) => Directory.Exists(path);
    }
}
