using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics
{
    public class Queries
    {
        public List<string> GetNamesOfAvailableClinics() => GenerateData.Clinics.Select(x=>x.Name).ToList();
        public List<string> GetSpecializationsOfHospital(Clinic clinic) 
        {
            return clinic.Doctors
                .Select(x=>x.Type.ToString())
                .ToList();
        }

        public List<string> GetPatients(Clinic clinic)
        {
            return clinic.Doctors
                .SelectMany(x=>x.ListOfAppointments.Values.Select(x=> string.Join(" ", x.Name, x.Surname)))
                .ToList();
        }

        public List<string> GetFreeHoursOfDoctor(Doctor doctor) => doctor.ListOfAppointments.Select(x => x.Key.ToString()).ToList(); 
    }
}
