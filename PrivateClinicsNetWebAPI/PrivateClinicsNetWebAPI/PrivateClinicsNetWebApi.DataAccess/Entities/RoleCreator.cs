using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClinicsNetWebApi.DataAccess.Entities
{
    public class RoleCreator
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleCreator(RoleManager<IdentityRole> roleManager) 
        {
            _roleManager = roleManager;
        }
    }
}
