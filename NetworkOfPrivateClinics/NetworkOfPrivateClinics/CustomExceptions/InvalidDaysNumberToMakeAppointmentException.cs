using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.CustomExceptions
{
    public class InvalidDaysNumberToMakeAppointmentException:Exception
    {
        public InvalidDaysNumberToMakeAppointmentException(string hour) 
            : base(String.Format($"Invalid day to make appointment: {hour}")) { }
    }
}
