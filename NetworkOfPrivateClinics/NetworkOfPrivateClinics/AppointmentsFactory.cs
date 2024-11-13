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
        public AppointmentsFactory(string startWorkingDay, string endWorkingDay)
        {
            StartWorkingDay = ConvertToTimeOnly(startWorkingDay);
            EndWorkingDay = ConvertToTimeOnly(endWorkingDay);
            AmountDaysInCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
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

        private TimeOnly ConvertToTimeOnly(string time) => TimeOnly.Parse(time, new CultureInfo("uk-UA"));
    }
}
