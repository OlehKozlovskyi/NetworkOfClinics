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
        public int AmountDaysInCurrentMonth { get;}
        public string StartWorkingDay { get; }
        public string EndWorkingDay { get; }

        public AppointmentFactory(string startWorkingDay, string endWorkingDay)
        {
            StartWorkingDay = startWorkingDay;
            EndWorkingDay = endWorkingDay;
            AmountDaysInCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
        }
        
        public Dictionary<int, DailyRoutine> GetAppointment()
        {
            var appointment = new Dictionary<int, DailyRoutine>();
            int currentNumberOfDay = DateTime.Now.Day;
            for (int i = currentNumberOfDay; i <= AmountDaysInCurrentMonth; i++)
                appointment.Add(i, new DailyRoutine(StartWorkingDay, EndWorkingDay));
            return appointment;
        }
    }
}
