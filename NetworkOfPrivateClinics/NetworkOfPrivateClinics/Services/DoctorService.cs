using Microsoft.Extensions.Logging;
using NetworkOfPrivateClinics.BusinessLogic;
using NetworkOfPrivateClinics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.Services
{
    public class DoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task RegisterDoctorAsync(Doctor doctor)
        {
            ArgumentNullException.ThrowIfNull(doctor);
            await semaphore.WaitAsync();
            try
            {
                await _doctorRepository.AddAsync(doctor);
            }
            finally
            {
                semaphore.Release();
            }
        }

        public async Task<Doctor> GetDoctorAsync(int id) => await _doctorRepository.GetByIdAsync(id);

        public async Task UpdateAsync(Doctor doctor)
        {
            ArgumentNullException.ThrowIfNull(doctor);
            await semaphore.WaitAsync();
            try
            {
                await _doctorRepository.UpdateAsync(doctor);
            }
            finally
            {
                semaphore.Release();
            }
        }

        public async Task<List<Doctor>> GetAllDoctorsAsync() => await _doctorRepository.GetAllDoctorsAsync();
        
        public async Task DeleteAsync(int id)
        {
            var doctor = await GetDoctorAsync(id);
            await _doctorRepository.DeleteAsync(doctor);
        }

        public async Task MakeAppointmentAsync(int dayNumber, string hour, int doctorID, Patient patient)
        {
            var existingDoctor = await _doctorRepository.GetByIdAsync(doctorID);
            ArgumentNullException.ThrowIfNull(existingDoctor);
            TimeOnly time = hour.ToTimeOnly();
            await semaphore.WaitAsync();
            try
            {
                await _doctorRepository.MakeAppointmentAsync(dayNumber, time, existingDoctor, patient);  
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}
