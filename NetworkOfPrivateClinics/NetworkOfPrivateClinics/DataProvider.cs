using NetworkOfPrivateClinics.BisinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics
{
    public class DataProvider
    {
        private List<Clinic> _clinicList;

        public DataProvider(List<Clinic> clinics) 
        {
            _clinicList = clinics;
        }
        public void GetAllHospitalsWithDoctors()
        {
            foreach (Clinic currentClinic in _clinicList)
            {
                Console.WriteLine($"Name: {currentClinic.ClinicsName}");
                Console.WriteLine($"Location: {currentClinic.Location}");
                foreach (Doctor currentDoctor in currentClinic.Doctors)
                    Console.WriteLine($"Doctor: {currentDoctor.DoctorsName} {currentDoctor.DoctorsSurname} - {currentDoctor.Type}");
                Console.WriteLine();
            }
        }

        public void GetHospitalWithDoctorsById()
        {
            Console.WriteLine("Enter clinics ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Clinic currentClinic = _clinicList.Where(x => x.ClinicID == id).Single();
            Console.WriteLine($"Name: {currentClinic.ClinicsName}");
            Console.WriteLine($"Location: {currentClinic.Location}");
            foreach (Doctor currentDoctor in currentClinic.Doctors)
                Console.WriteLine($"Doctor: {currentDoctor.DoctorsName} {currentDoctor.DoctorsSurname} - {currentDoctor.Type}");
        }
    }
}
