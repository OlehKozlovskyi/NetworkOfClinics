using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.CustomExceptions
{
    public class InvalidFileExtension:Exception
    {
        public InvalidFileExtension(string file)
            :base(string.Format($"Invalid file extension: {file}")) { }
    }
}
