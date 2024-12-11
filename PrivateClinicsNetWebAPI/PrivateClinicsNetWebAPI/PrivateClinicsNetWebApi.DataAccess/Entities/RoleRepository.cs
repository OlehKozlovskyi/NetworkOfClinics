using Microsoft.AspNetCore.Identity;
using PrivateClinicsNetWebApi.DataAccess.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClinicsNetWebApi.DataAccess.Entities
{
    //Implement Crud operations 
    public class RoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleRepository(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task AddRole(string roleName)
        {
            if (await _roleManager.RoleExistsAsync(roleName))
                throw new RoleAlreadyExistException(roleName);
            await _roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }
}
