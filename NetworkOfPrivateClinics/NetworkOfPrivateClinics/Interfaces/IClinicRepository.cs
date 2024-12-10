using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkOfPrivateClinics.BusinessLogic;

namespace NetworkOfPrivateClinics.Interfaces
{
    public interface IClinicRepository
    {
        List<Clinic> GetClinics();
        Clinic GetClinicById(int id);
        void AddClinic(Clinic clinic);
        void DeleteClinic(Clinic clinic);
    }
}
