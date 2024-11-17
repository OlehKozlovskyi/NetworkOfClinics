using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkOfPrivateClinics.BisinessLogic;

namespace NetworkOfPrivateClinics.Interfaces
{
    public interface IClinicRepository
    {
        IEnumerable<Clinic> GetClinics();
        Clinic GetClinicById(int id);
        void InsertClinic(Clinic clinic);
        void DeleteClinic(int id);
    }
}
