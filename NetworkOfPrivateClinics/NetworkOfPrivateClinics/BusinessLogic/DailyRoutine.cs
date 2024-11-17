using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.BisinessLogic
{
    public class DailyRoutine
    {
        public readonly TimeOnly StartWorkingDay;
        public readonly TimeOnly EndWorkingDay;

        public DailyRoutine(TimeOnly startWorkingDay, TimeOnly endWorkingDay)
        {
            StartWorkingDay = startWorkingDay;
            EndWorkingDay = endWorkingDay;
            ListOfDailyAppointments = GenerateDailyRoutine(StartWorkingDay, EndWorkingDay);
        }

        public Dictionary<TimeOnly, Patient> ListOfDailyAppointments { get; set; }

        public Patient this[TimeOnly time]
        {
            get => ListOfDailyAppointments[time];
            set => ListOfDailyAppointments[time] = value;
        }

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
    }
}
