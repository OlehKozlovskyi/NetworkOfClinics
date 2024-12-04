using Microsoft.Extensions.Logging;
using NetworkOfPrivateClinics.BisinessLogic;
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
        private readonly ICustomLogger _logger;

        public DoctorService(IDoctorRepository doctorRepository, ICustomLogger logger)
        {
            _doctorRepository = doctorRepository;
            _logger = logger;
        }

        public async Task RegisterDoctorAsync(Doctor doctor)
        {
            ArgumentNullException.ThrowIfNull(doctor);
            SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1,5);
            await semaphoreSlim.WaitAsync();
            try
            {
                await _doctorRepository.AddAsync(doctor);
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }

        public async Task<Doctor> GetDoctorAsync(int id) => await _doctorRepository.GetByIdAsync(id);

        public async Task UpdateAsync(Doctor doctor)
        {
            ArgumentNullException.ThrowIfNull(doctor);
            SemaphoreSlim semaphore = new SemaphoreSlim(1);
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

        public async Task MakeAppointment(int dayNumber, string hour, int doctorID, Patient patient)
        {
            var existingDoctor = await _doctorRepository.GetByIdAsync(doctorID);
            ArgumentNullException.ThrowIfNull(existingDoctor);
            bool isAppointmentBook = false;
            TimeOnly time = hour.ToTimeOnly();
            SemaphoreSlim semaphore = new SemaphoreSlim(1);
            await semaphore.WaitAsync();
            try
            {
                isAppointmentBook = await _doctorRepository.TryMakeAppointmentAsync(dayNumber, time, existingDoctor, patient);
                if (isAppointmentBook)
                    await _logger.LogInformation($"Appointment booked with {patient.PatientName} {patient.PatientSurname} at {time}");
                else
                {
                    await _logger.LogWarning($"Conflict! Time {hour} is already booked!!!");
                    var shiftedTime = time.AddHours(1);
                    await _doctorRepository.TryMakeAppointmentAsync(dayNumber, shiftedTime, existingDoctor, patient);
                }
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}
