using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.CustomExceptions
{
    public class NotFoundPathsToSupportedFilesException : Exception
    {
        public NotFoundPathsToSupportedFilesException(string[] paths)
            :base(String.Format($"Not found paths to supported files: {paths.Length}")){ }
    }
}
