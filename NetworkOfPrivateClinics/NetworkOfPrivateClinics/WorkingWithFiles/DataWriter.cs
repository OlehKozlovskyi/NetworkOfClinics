using NetworkOfPrivateClinics.BisinessLogic;
using NetworkOfPrivateClinics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public class DataWriter
    {
        public void Write(ClinicRepository clinicRepository, IFileWriter writer)
        {
            writer.Write(clinicRepository);
        }
    }
}
