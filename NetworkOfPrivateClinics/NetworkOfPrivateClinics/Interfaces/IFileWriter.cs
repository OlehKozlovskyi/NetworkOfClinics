using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkOfPrivateClinics.BisinessLogic;

namespace NetworkOfPrivateClinics.Interfaces
{
    public interface IFileWriter
    {
        public void Write(ClinicRepository clinicsList);
    }
}
