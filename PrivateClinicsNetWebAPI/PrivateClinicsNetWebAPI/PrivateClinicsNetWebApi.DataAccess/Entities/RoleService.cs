using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClinicsNetWebApi.DataAccess.Entities
{
    //ImplememntOperationCrud and use repository
    public class RoleService
    {
        private readonly RoleRepository _roleRepository;

        public RoleService(RoleRepository roleRepository) 
        {
            _roleRepository = roleRepository;
        }

        public async Task AddRole(string roleName)
        {

        }
    }
}
