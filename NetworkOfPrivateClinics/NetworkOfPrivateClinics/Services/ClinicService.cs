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

        public async Task AddClinicAsync(Clinic clinic) 
        {
            ArgumentNullException.ThrowIfNull(clinic);
            SemaphoreSlim semaphore = new SemaphoreSlim(1,5);
            await semaphore.WaitAsync();
            try
            {
                await _clinicRepository.AddClinicAsync(clinic);
            }
            finally
            {
                semaphore.Release();
            }
        }

        public async Task<List<Clinic>> GetAllClinicsAsync() => await _clinicRepository.GetClinicsAsync();

        public async Task<Clinic> GetClinicAsync(int clinicID) 
        {
            var clinic = await _clinicRepository.GetClinicByIdAsync(clinicID);
            if(clinic == null)
            {
                throw new ClinicNotFoundException(clinicID);
            }
            return clinic;
        }

        public async Task RemoveClinicAsync(int clinicID) 
        {
            SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1);
            Clinic existingClinic = await GetClinicAsync(clinicID);
            await semaphoreSlim.WaitAsync();
            try
            {
                await _clinicRepository.DeleteClinicAsync(existingClinic);
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }
    }
}
