using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics
{
    public class AppointmentFactory
    {
        public readonly int AmountDaysInCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

        public AppointmentFactory(string startWorkingDay, string endWorkingDay)
        {
            Appointment = new Dictionary<int, DailyRoutine>();
            int currentNumberOfDay = DateTime.Now.Day;
            for (int i = currentNumberOfDay; i <= AmountDaysInCurrentMonth; i++)
                Appointment.Add(i, new DailyRoutine(startWorkingDay, endWorkingDay));
        }

        public Dictionary<int, DailyRoutine> Appointment { get; set; }

        public DailyRoutine this[int daysNumber]
        {
            get
            {
                return Appointment[daysNumber];
            }
        }
    }
}
