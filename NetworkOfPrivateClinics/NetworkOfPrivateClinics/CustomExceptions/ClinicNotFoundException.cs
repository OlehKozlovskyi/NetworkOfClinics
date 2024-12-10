using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.CustomExceptions
{
    public class ClinicNotFoundException:Exception
    {
        public ClinicNotFoundException(int id)
            : base(string.Format($"Doctor with such id hasn`t been register: {id}")){ }
    }
}
