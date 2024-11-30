using NetworkOfPrivateClinics.BisinessLogic;
using NetworkOfPrivateClinics.CustomExceptions;
using NetworkOfPrivateClinics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.BusinessLogic
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly List<Doctor> _doctors = new();
        private static readonly object _locker = new object();

        public async Task AddAsync(Doctor doctor)
        {
            await Task.Run(() =>
            {
                lock (_locker)
                {
                    _doctors.Add(doctor);
                }
            });
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Run(() =>
            {
                lock (_locker)
                {
                    var doctor = GetByIdAsync(id).Result;
                    _doctors.Remove(doctor);
                }
            });
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await Task.FromResult(_doctors);
        }

        public async Task<Doctor> GetByIdAsync(int id)
        {
            var result = await Task.FromResult(_doctors.Single(doctor => doctor.DoctorID == id));
            if (result == null)
                throw new DoctorNotFoundException(id);
            return result;
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            await Task.Run(() =>
            {
                var existingDoctor = _doctors.FirstOrDefault(currentDoctor => currentDoctor.DoctorID == doctor.DoctorID);
                if(existingDoctor == null)
                    throw new DoctorNotFoundException()
            })
        }
    }
}
