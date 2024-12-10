using NetworkOfPrivateClinics.BusinessLogic;
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

        public void Add(Doctor doctor) => _doctors.Add(doctor);

        public List<Doctor> GetAllDoctors() => _doctors;
   

        public Doctor GetById(int id)
        {
            var result = _doctors.First(doctor => doctor.DoctorID == id);
            if (result == null)
                throw new DoctorNotFoundException(id);
            return result;
        }

        public void Update(Doctor doctor)
        {
            var existingDoctor = _doctors.Single(currentDoctor => currentDoctor.DoctorID == doctor.DoctorID);
            if (existingDoctor == null)
                throw new DoctorNotFoundException(doctor.DoctorID);
            existingDoctor.DoctorsName = doctor.DoctorsName;
            existingDoctor.DoctorsSurname = doctor.DoctorsSurname;
            existingDoctor.Type = doctor.Type;
            existingDoctor.CostOfAdmission = doctor.CostOfAdmission;
            existingDoctor.Appointments = doctor.Appointments;
        }

        public void MakeAppointment(int dayNumber, TimeOnly hour, Doctor doctor, Patient patient)
        {
            var isAppointmentBooked = doctor.TryMakeAppointmentAsync(dayNumber, hour, patient);
            if (isAppointmentBooked)
                _logger.LogInformation($"Appointment booked with {patient.PatientName} {patient.PatientSurname} at {hour}");
            else
            {
                var shiftedTime = hour.AddHours(1);
                MakeAppointment(dayNumber, shiftedTime, doctor, patient);
            }
        }

        public void Delete(Doctor doctor) => _doctors.Remove(doctor);
    }
}
