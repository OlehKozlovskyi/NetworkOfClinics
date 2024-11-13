using NetworkOfPrivateClinics.CustomExceptions;
using NetworkOfPrivateClinics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics
{
    public class ClinicRepository : IClinicRepository
    {
        public ClinicRepository(List<Clinic> clinicContext) 
        {
            context = clinicContext;
        }

        private readonly List<Clinic> context;

        public void DeleteClinic(int id)
        {
            Clinic clinic = context.First(x => x.ClinicID == id);
            context.Remove(clinic);
        }

        public Clinic GetClinicById(int id) => context.First(x => x.ClinicID == id);

        public IEnumerable<Clinic> GetClinics() => context;

        public void InsertClinic(Clinic clinic) => context.Add(clinic);
    }
}
