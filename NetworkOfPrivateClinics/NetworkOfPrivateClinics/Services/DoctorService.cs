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

        public async Task<List<Doctor>> GetAllDoctorsAsync() => await _doctorRepository.GetAllDoctorsAsync();

        public async Task<bool> MakeAppointment(Patient patient)
        {
            await _doctorRepository.
        }
    }
}
