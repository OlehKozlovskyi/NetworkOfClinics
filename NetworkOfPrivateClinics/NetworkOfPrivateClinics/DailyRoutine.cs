using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics
{
    public class DailyRoutine
    {
        public Dictionary<TimeOnly, Patient> ListOfDailyAppointments { get; set; }

        public DailyRoutine(string startWorkingDay, string endWorkingDay)
        {
            StartWorkingDay = ConvertToTimeOnly(startWorkingDay);
            EndWorkingDay = ConvertToTimeOnly(endWorkingDay);
            ListOfDailyAppointments = GenerateDailyRoutine(StartWorkingDay, EndWorkingDay);
        }

        public readonly TimeOnly StartWorkingDay;
        public readonly TimeOnly EndWorkingDay;

        private TimeOnly ConvertToTimeOnly(string time) => TimeOnly.Parse(time, new CultureInfo("uk-UA"));

        private Dictionary<TimeOnly, Patient> GenerateDailyRoutine(TimeOnly startWorkingDay, TimeOnly endWorkingDay)
        {
            TimeOnly currentTime = startWorkingDay;
            Dictionary<TimeOnly, Patient> generatedList = new();
            while (currentTime < endWorkingDay)
            {
                generatedList.Add(currentTime, null);
                currentTime = currentTime.AddHours(1);
            }
            return generatedList;
        }

        public Patient this[TimeOnly time]
        {
            get => ListOfDailyAppointments[time];
            set => ListOfDailyAppointments[time] = value;
        }
    }
}
