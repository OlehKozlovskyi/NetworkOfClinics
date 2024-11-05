using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics
{
    public class Doctor
    {
        public static int DoctorID { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public double CostOfPermissiom {  get; private set; }
        public Dictionary<TimeSpan, Patient> ListOfAppointments { get; set; }
    }
}
