using NetworkOfPrivateClinics.BusinessLogic;
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
        Task<List<Doctor>> GetAllDoctorsAsync();
        Task UpdateAsync(Doctor doctor);
        Task DeleteAsync(Doctor doctor);
        Task<Doctor> GetByIdAsync(int id);
        Task MakeAppointmentAsync(int dayNumber, TimeOnly hour, Doctor doctor, Patient patient);
    }
}
