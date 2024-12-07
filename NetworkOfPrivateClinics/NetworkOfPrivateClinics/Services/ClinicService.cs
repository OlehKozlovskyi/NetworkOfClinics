using NetworkOfPrivateClinics.BusinessLogic;
using NetworkOfPrivateClinics.CustomExceptions;
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

        public void AddClinic(Clinic clinic) 
        {
            ArgumentNullException.ThrowIfNull(clinic);
            _clinicRepository.AddClinic(clinic);
        }

        public List<Clinic> GetAllClinics() => _clinicRepository.GetClinics();

        public Clinic GetClinic(int clinicID) 
        {
            var clinic = _clinicRepository.GetClinicById(clinicID);
            if(clinic == null)
                throw new ClinicNotFoundException(clinicID);
            return clinic;
        }

        public void RemoveClinic(int clinicID) 
        {
            Clinic existingClinic = GetClinic(clinicID);
                _clinicRepository.DeleteClinic(existingClinic);
        }
    }
}
