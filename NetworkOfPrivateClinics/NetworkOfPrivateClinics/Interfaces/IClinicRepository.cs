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
        Task<IEnumerable<Clinic>> GetClinics();
        Task<Clinic> GetClinicById(int id);
        Task AddClinic(Clinic clinic);
        Task DeleteClinic(int id);
    }
}
