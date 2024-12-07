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

        public void AddClinic(Clinic clinic) => _clinics.Add(clinic);

        public void DeleteClinic(Clinic clinic) => _clinics.Remove(clinic);

        public Clinic GetClinicById(int id) => _clinics.First(x => x.ClinicID == id);

        public List<Clinic> GetClinics() => _clinics;
    }
}
