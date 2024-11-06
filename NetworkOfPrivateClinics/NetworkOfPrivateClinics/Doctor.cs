using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics
{
    public enum DoctorType
    {
        Neurologist,
        Gastroenterologist,
        Cardiology,
        Oncologist,
        Psychiatrist,
        Dermatologist,
        Anasthesiologist
    }

    public class Doctor
    {
        public static int DoctorID { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public DoctorType Type { get; private set; }
        public double CostOfPermissiom {  get; private set; }
        public Dictionary<TimeOnly, Patient> ListOfAppointments { get; set; }

        public Doctor(string name, string surname, DoctorType type, double costOfPermissiom)
        {
            Name = name;
            Surname = surname;
            Type = type;
            CostOfPermissiom = costOfPermissiom;
            ListOfAppointments = InitListOfAppointments();
        }

        private Dictionary<TimeOnly, Patient> InitListOfAppointments()
        {
            const int startWorkingDayAtHour = 8;
            TimeOnly EndWorkingDay = TimeOnly.MinValue.AddHours(17);
            TimeOnly selectedTime = TimeOnly.MinValue.AddHours(startWorkingDayAtHour);
            Dictionary<TimeOnly, Patient> tempListOfAppointments = new();
            while (selectedTime < EndWorkingDay)
            {
                tempListOfAppointments.Add(selectedTime, null);
                selectedTime = selectedTime.AddMinutes(30);
            }
            return tempListOfAppointments;
        }
    }
}
