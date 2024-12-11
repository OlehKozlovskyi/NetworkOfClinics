using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClinicsNetWebApi.DataAccess.Exceptions
{
    public class RoleAlreadyExistException:Exception
    {
        public RoleAlreadyExistException(string roleName) 
            :base(String.Format($"The role {roleName} is already exist in the application.")){ }
    }
}
