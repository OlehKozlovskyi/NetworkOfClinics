using NetworkOfPrivateClinics.BisinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public abstract class BaseWriter
    {
        public abstract void Write(List<Clinic> clinicsList);
    }
}
