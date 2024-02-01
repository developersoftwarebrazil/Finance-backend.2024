using Microsoft.AspNetCore.Identity;

namespace Finance.Domain.Entity.Entities.Users.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public String Name { get; set; }
    }
}
