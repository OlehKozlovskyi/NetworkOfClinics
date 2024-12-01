using NetworkOfPrivateClinics.CustomExceptions;
using NetworkOfPrivateClinics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.BisinessLogic
{
    public class ClinicRepository : IClinicRepository
    {
        private readonly List<Clinic> _clinics = new();
        private static readonly object _locker = new object();

        public async Task AddClinic(Clinic clinic)
        {
            await Task.Run(() =>
            {
                lock (_locker)
                {
                    ArgumentNullException.ThrowIfNull(clinic);
                    _clinics.Add(clinic);
                }
            });
        }

        public async Task DeleteClinic(int id)
        {
            await Task.Run(() =>
            {
                lock (_locker)
                {
                    Clinic existingClinic = GetClinicById(id).Result;
                    _clinics.Remove(existingClinic);
                }
            });
        }

        public async Task<Clinic> GetClinicById(int id)
        {
            Clinic clinic = await Task.FromResult(_clinics.First(x => x.ClinicID == id));
            if (clinic == null)
                throw new ClinicNotFoundException(id);
            return clinic;
        }

        public async Task<IEnumerable<Clinic>> GetClinics()
        {
            return await Task.FromResult(_clinics);
        }
    }
}
