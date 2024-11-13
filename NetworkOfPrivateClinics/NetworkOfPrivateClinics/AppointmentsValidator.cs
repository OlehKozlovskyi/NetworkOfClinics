using NetworkOfPrivateClinics.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics
{
    public class AppointmentsValidator
    {
        private TimeOnly startWorkingDay;
        private TimeOnly endWorkingDay;
        
        public AppointmentsValidator(string startWorkingDay, string endWorkingDay) 
        {
            this.startWorkingDay = startWorkingDay.ToTimeOnly();
            this.endWorkingDay = endWorkingDay.ToTimeOnly();
        }

        public bool IsNumberValid(int daysNumber)
        {
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;
            if ((daysNumber > DateTime.DaysInMonth(currentYear, currentMonth)) || (daysNumber < 0))
                throw new InvalidDaysNumberToMakeAppointmentException(nameof(daysNumber));
            return true;
        }

        public bool IsHourValid(TimeOnly hour)
        {
            if (!hour.IsBetween(startWorkingDay, endWorkingDay))
                throw new InvalidHourToMakeAppointmentException(nameof(hour));
            return true;
        }
    }
}
