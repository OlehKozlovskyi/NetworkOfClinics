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
        private readonly List<Clinic> _context = new();

        public Task AddClinic(Clinic clinic)
        {
            throw new NotImplementedException();
        }

        public Task DeleteClinic(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Clinic> GetClinicById(int id)
        {
            Clinic clinic = await Task.FromResult(_context.First(x => x.ClinicID == id));
            if(clinic == null)
                throw new 
        }

        public async Task<IEnumerable<Clinic>> GetClinics()
        {
            return await Task.FromResult(_context);
        }


        //public ClinicRepository(List<Clinic> clinicContext)
        //{
        //    _context = clinicContext;
        //}



        //public void DeleteClinic(int id)
        //{
        //    Clinic clinic = _context.First(x => x.ClinicID == id);
        //    _context.Remove(clinic);
        //}

        //public Clinic GetClinicById(int id) => _context.First(x => x.ClinicID == id);

        //public IEnumerable<Clinic> GetClinics() => _context;

        //public void AddClinic(Clinic clinic) => _context.Add(clinic);
    }
}
