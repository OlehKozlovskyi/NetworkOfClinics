using NetworkOfPrivateClinics.BisinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.Interfaces
{
    public interface IDoctorRepository
    {
        Task AddAsync(Doctor doctor);
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task UpdateAsync(Doctor doctor);
        Task DeleteAsync(int id);
        Task<Doctor> GetByIdAsync(int id);
    }
}
