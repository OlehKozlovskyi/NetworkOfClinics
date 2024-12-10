using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.CustomExceptions
{
    public class DoctorNotFoundException:Exception
    {
        public DoctorNotFoundException(int id)
            : base(String.Format($"Doctor with  such id hasn`t been register: {id}")) { }
    }
}
