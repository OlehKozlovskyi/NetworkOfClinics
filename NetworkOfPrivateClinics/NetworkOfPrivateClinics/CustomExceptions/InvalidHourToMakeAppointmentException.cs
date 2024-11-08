using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.CustomExceptions
{
    public class InvalidHourToMakeAppointmentException:Exception
    {
        public InvalidHourToMakeAppointmentException(string hour) 
            : base(String.Format($"Invalid hour to make appointment: {hour}")) { }
    }
}
