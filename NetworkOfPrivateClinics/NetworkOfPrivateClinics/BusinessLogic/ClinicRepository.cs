using NetworkOfPrivateClinics.CustomExceptions;
using NetworkOfPrivateClinics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.BusinessLogic
{
    public class ClinicRepository : IClinicRepository
    {
        private readonly List<Clinic> _clinics = new();

        public async Task AddClinicAsync(Clinic clinic)
        {
            await Task.Run(() =>
            {
                _clinics.Add(clinic);
            });
        }

        public async Task DeleteClinicAsync(Clinic clinic)
        {
            await Task.Run(() =>
            {
                _clinics.Remove(clinic);
            });
        }

        public async Task<Clinic> GetClinicByIdAsync(int id)
        {
            return await Task.FromResult(_clinics.First(x => x.ClinicID == id));
        }

        public async Task<List<Clinic>> GetClinicsAsync()
        {
            return await Task.FromResult(_clinics);
        }
    }
}
