using NetworkOfPrivateClinics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public struct CvsFileFormat : IFormat
    {
        public string Extension { get; }

        public CvsFileFormat(string extension)
        {
            Extension = extension;
        }
    }
}
