using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.CustomExceptions
{
    public class InvalidMakeAppointmentException:Exception
    {
        public InvalidMakeAppointmentException(string message)
            :base (String.Format($"Invalid make appointment make appintment operation: {message}")) { }
    }
}
