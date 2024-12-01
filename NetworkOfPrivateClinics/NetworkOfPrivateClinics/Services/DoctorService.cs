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

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<Doctor> GetDoctorAsync(int id) => await _doctorRepository.GetByIdAsync(id);
        
        public async Task RegisterDoctorAsync(Doctor doctor) => await _doctorRepository.AddAsync(doctor);

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync() => await _doctorRepository.GetAllDoctorsAsync();

        public async Task MakeAppointment(int doctorId, int dayNumber, string hour, Patient patient)
        {
            bool isCompleted = await _doctorRepository.TryMakeAppointmentAsync(doctorId, dayNumber, hour, patient);
            if (isCompleted)
                await Console.Out.WriteLineAsync("Your appointment has been successfully created");
            else
                await Console.Out.WriteLineAsync("Your appointment has been failed");

        }
    }
}
