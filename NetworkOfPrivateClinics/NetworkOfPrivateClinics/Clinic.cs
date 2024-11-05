using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics
{
    public class Clinic
    {
        public static int ID { get; private set; }
        public string Name { get; private set; }
        public string Location {  get; private set; }
        public List<Doctor> Doctors { get; private set; }

        public Clinic(string name, string location, List<Doctor> doctors)
        {
            ID += 1;
            Name = name;
            Location = location;
            Doctors = doctors;
        }

        public void AddDoctor(Doctor doctor) => Doctors.Add(doctor);
    }
}
