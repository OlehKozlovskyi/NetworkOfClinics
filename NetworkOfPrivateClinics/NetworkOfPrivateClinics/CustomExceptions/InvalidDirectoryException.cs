using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.CustomExceptions
{
    public class InvalidDirectoryException : Exception
    {
        public InvalidDirectoryException(string path)
            : base(String.Format($"Invalid directory: {path}")) { }
    }
}
