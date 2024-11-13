using NetworkOfPrivateClinics.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics
{
    public class AppointmentsFactory
    {
        public readonly AppointmentsValidator appointmentValidator;

        public AppointmentsFactory(string startWorkingDay, string endWorkingDay, AppointmentsValidator validator)
        {
            StartWorkingDay = ConvertToTimeOnly(startWorkingDay);
            EndWorkingDay = ConvertToTimeOnly(endWorkingDay);
            AmountDaysInCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            appointmentValidator = validator;
        }

        public int AmountDaysInCurrentMonth { get; }
        public TimeOnly StartWorkingDay { get; }
        public TimeOnly EndWorkingDay { get; }


        public Dictionary<int, DailyRoutine> GetMonthlyAppointment()
        {
            var appointment = new Dictionary<int, DailyRoutine>();
            int currentNumberOfDay = DateTime.Now.Day;
            for (int i = currentNumberOfDay; i <= AmountDaysInCurrentMonth; i++)
                appointment.Add(i, new DailyRoutine(StartWorkingDay, EndWorkingDay));
            return appointment;
        }
        /*
        public Dictionary<int, DailyRoutine> ModifyAppointment(Dictionary<int, DailyRoutine> appointmentsList, int daysNumber, TimeOnly hour, Patient patient)
        {
            if (!appointmentValidator.IsNumberValid(daysNumber))
                throw new InvalidDaysNumberToMakeAppointmentException(nameof(daysNumber));
            if(!appointmentValidator.IsHourValid(hour))
                throw new InvalidHourToMakeAppointmentException(nameof(daysNumber));
            appointmentsList[daysNumber][hour] = patient;
            return appointmentsList;
        }
        */
        private TimeOnly ConvertToTimeOnly(string time) => TimeOnly.Parse(time, new CultureInfo("uk-UA"));
    }
}
