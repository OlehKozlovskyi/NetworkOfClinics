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
        private readonly List<Clinic> _context;

        public ClinicRepository(List<Clinic> clinicContext) 
        {
            _context = clinicContext;
        }

        public void DeleteClinic(int id)
        {
            Clinic clinic = _context.First(x => x.ClinicID == id);
            _context.Remove(clinic);
        }

        public Clinic GetClinicById(int id) => _context.First(x => x.ClinicID == id);

        public IEnumerable<Clinic> GetClinics() => _context;

        public void InsertClinic(Clinic clinic) => _context.Add(clinic);
    }
}
