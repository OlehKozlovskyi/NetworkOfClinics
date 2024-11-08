using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkOfPrivateClinics.CustomExceptions;
using NetworkOfPrivateClinics.Exceptions;

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
        public Doctor(string name, string surname, DoctorType type, double costOfPermissiom)
        {
            Name = name;
            Surname = surname;
            Type = type;
            CostOfAdmission = costOfPermissiom;
            ListOfAppointments = InitListOfAppointments();
        }

        public static int DoctorID { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public DoctorType Type { get; private set; }
        public double CostOfAdmission { get; private set; }
        public Dictionary<TimeOnly, Patient> ListOfAppointments { get; set; }


        public void MakeAppointment(TimeOnly hour, Patient patient)
        {
            if (!ListOfAppointments.ContainsKey(hour))
                throw new InvalidHourToMakeAppointmentException(hour.ToString());
            ListOfAppointments[hour] = patient;
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
                selectedTime = selectedTime.AddHours(1);
            }
            return tempListOfAppointments;
        }
    }
}
