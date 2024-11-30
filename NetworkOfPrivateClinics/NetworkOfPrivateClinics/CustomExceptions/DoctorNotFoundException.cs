using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.CustomExceptions
{
    public class DoctorNotFoundException:Exception
    {
        public DoctorNotFoundException()
            : base(String.Format($"Doctor with that id doesn`t exist")) { }
    }
}
