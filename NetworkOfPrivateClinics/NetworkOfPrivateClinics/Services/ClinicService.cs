using NetworkOfPrivateClinics.BisinessLogic;
using NetworkOfPrivateClinics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.Services
{
    public class ClinicService
    {
        private readonly IClinicRepository _clinicRepository;
        
        public ClinicService(IClinicRepository repository) 
        {
            _clinicRepository = repository;
        }

        public async Task AddClinicAsync(Clinic clinic) => await _clinicRepository.AddClinicAsync(clinic);

        public async Task<List<Clinic>> GetAllClinicsAsync() => await _clinicRepository.GetClinicsAsync();
        
        public async Task<Clinic> GetClinicAsync(int clinicID) => await _clinicRepository.GetClinicByIdAsync(clinicID);

        public async Task RemoveClinicAsync(int clinicID) => await _clinicRepository.DeleteClinicAsync(clinicID);
    }
}
