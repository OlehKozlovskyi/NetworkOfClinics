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
        public AppointmentFactory(string startWorkingDay, string endWorkingDay)
        {
            
        }

        public Dictionary<int, DailyRoutine> Appointment { get; set; }

        

    }
}
