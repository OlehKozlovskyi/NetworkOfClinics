using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.CustomExceptions
{
    public class UnsupportedFileException:Exception
    {
        public UnsupportedFileException(string file)
            :base(string.Format($"Invalid file extension: {file}")){ }
    }
}
