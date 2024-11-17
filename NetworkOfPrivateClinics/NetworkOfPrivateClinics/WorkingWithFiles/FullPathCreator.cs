using NetworkOfPrivateClinics.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public class FullPathCreator
    {
        private string _path;
        private string _fileName;
        private IExtension _type;

        public FullPathCreator(string path, string fileName, IExtension type) 
        {
            _path = path;
            _fileName = fileName;
            _type = type;
        }

        public string GetFullPath() => string.Concat(_path, '\\', _fileName, _type.Extension);
    }
}
