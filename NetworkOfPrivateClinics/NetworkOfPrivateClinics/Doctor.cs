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
        public Doctor(int id, string name, string surname, DoctorType type, decimal costOfPermissiom)
        {
            DoctorID = id;
            Name = name;
            Surname = surname;
            Type = type;
            CostOfAdmission = costOfPermissiom;
            Appointments = new AppointmentFactory("8:00", "17:00");
        }

        public int DoctorID { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public DoctorType Type { get; private set; }
        public decimal CostOfAdmission { get; private set; }
        public AppointmentFactory Appointments { get; set; }


        public void MakeAppointment(int daysNumber, TimeOnly hour, Patient patient)
        {
            if (IsDaysNumberAndHourValid(daysNumber,hour))
                Appointments[daysNumber][hour] = patient;
        }

        private bool IsDaysNumberAndHourValid(int daysNumber, TimeOnly hour)
        {
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;
            if ((daysNumber > DateTime.DaysInMonth(currentYear, currentMonth)) || (daysNumber < 0))
                throw new InvalidDaysNumberToMakeAppointmentException(nameof(daysNumber));
            TimeOnly startWorkingDay = Appointments[daysNumber].ListOfDailyAppointments.First().Key;
            TimeOnly endWorkingDay = Appointments[daysNumber].ListOfDailyAppointments.Last().Key;
            if (!hour.IsBetween(startWorkingDay, endWorkingDay))
                throw new InvalidHourToMakeAppointmentException(nameof(hour));
            return true;
        }
    }
}
