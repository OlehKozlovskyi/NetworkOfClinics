using NetworkOfPrivateClinics.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.Interfaces
{
    public interface IDoctorRepository
    {
        void Add(Doctor doctor);
        List<Doctor> GetAllDoctors();
        void Update(Doctor doctor);
        void Delete(Doctor doctor);
        Doctor GetById(int id);
        void MakeAppointment(int dayNumber, TimeOnly hour, Doctor doctor, Patient patient);
    }
}
