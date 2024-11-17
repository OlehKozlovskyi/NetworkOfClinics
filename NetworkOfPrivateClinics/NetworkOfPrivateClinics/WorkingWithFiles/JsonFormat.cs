using NetworkOfPrivateClinics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public struct JsonFormat : Interfaces.IExtension
    {
        public string Extension { get; }

        public JsonFormat(string extension)
        {
            Extension = extension;
        }
    }
}
