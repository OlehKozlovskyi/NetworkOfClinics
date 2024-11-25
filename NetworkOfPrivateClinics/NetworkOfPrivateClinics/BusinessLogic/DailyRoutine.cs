using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;

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
                generatedList.Add(currentTime, new Patient());
                currentTime = currentTime.AddHours(1);
            }
            return generatedList;
        }
    }
}
