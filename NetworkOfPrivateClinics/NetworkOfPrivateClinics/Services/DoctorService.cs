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
        private static readonly object _lockObject = new object();

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public void RegisterDoctor(Doctor doctor)
        {
            ArgumentNullException.ThrowIfNull(doctor);
            _doctorRepository.Add(doctor);
        }

        public Doctor GetDoctor(int id) => _doctorRepository.GetById(id);

        public void UpdateAsync(Doctor doctor)
        {
            ArgumentNullException.ThrowIfNull(doctor);
            _doctorRepository.Update(doctor);
        }

        public List<Doctor> GetAllDoctors() => _doctorRepository.GetAllDoctors();
        
        public void Delete(int id)
        {
            var doctor = GetDoctor(id);
            _doctorRepository.Delete(doctor);
        }

        public async Task MakeAppointmentAsync(int dayNumber, string hour, int doctorID, Patient patient)
        {
            var doctor = _doctorRepository.GetById(doctorID);
            ArgumentNullException.ThrowIfNull(doctor);
            TimeOnly time = hour.ToTimeOnly();
            lock (_lockObject)
            {
                _doctorRepository.MakeAppointment(dayNumber,time,doctor,patient);
            }
        }
    }
}
