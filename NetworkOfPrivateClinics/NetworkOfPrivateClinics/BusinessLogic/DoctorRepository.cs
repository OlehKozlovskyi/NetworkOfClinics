using NetworkOfPrivateClinics.BisinessLogic;
using NetworkOfPrivateClinics.CustomExceptions;
using NetworkOfPrivateClinics.Interfaces;
using NetworkOfPrivateClinics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.BusinessLogic
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly List<Doctor> _doctors = new();
        private readonly ICustomLogger _logger;

        public DoctorRepository(ICustomLogger logger)
        {
            _logger = logger;
        }

        public async Task AddAsync(Doctor doctor)
        {
            await Task.Run(() =>
            {
                _doctors.Add(doctor);
            });
        }

        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
            return await Task.FromResult(_doctors);
        }

        public async Task<Doctor> GetByIdAsync(int id)
        {
            var result = await Task.FromResult(_doctors.First(doctor => doctor.DoctorID == id));
            if (result == null)
                throw new DoctorNotFoundException(id);
            return result;
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            await Task.Run(() =>
            {
                var existingDoctor = _doctors.Single(currentDoctor => currentDoctor.DoctorID == doctor.DoctorID);
                if (existingDoctor == null)
                    throw new DoctorNotFoundException(doctor.DoctorID);
                existingDoctor.DoctorsName = doctor.DoctorsName;
                existingDoctor.DoctorsSurname = doctor.DoctorsSurname;
                existingDoctor.Type = doctor.Type;
                existingDoctor.CostOfAdmission = doctor.CostOfAdmission;
                existingDoctor.Appointments = doctor.Appointments;
            });
        }

        public async Task MakeAppointmentAsync(int dayNumber, TimeOnly hour, Doctor doctor, Patient patient)
        {
            var isAppointmentBook = await doctor.TryMakeAppointmentAsync(dayNumber, hour, patient);
            if (isAppointmentBook)
                await _logger.LogInformation($"Appointment booked with {patient.PatientName} {patient.PatientSurname} at {hour}");
            else
            {
                var shiftedTime = hour.AddHours(1);
                await MakeAppointmentAsync(dayNumber, shiftedTime, doctor, patient);
            }
        }

        public async Task DeleteAsync(Doctor doctor) => await Task.Run(() => _doctors.Remove(doctor));
    }
}
