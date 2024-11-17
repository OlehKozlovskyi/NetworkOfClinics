using NetworkOfPrivateClinics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public struct CsvFormat : Interfaces.IExtension
    {
        public string Extension { get; }

        public CsvFormat(string extension)
        {
            Extension = extension;
        }
    }
}
