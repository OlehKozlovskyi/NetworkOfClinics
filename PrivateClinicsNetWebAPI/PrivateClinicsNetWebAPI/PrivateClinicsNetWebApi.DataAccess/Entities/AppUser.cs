using Microsoft.AspNetCore.Identity;

namespace PrivateClinicsNetWebApi.DataAccess.Entities
{
    public class AppUser : IdentityUser
    {
        public string FullName {  get; set; }
    }
}
