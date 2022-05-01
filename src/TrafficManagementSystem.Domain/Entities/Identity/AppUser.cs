using Microsoft.AspNetCore.Identity;

namespace TrafficManagementSystem.Domain.Entities.Identity
{
    public class AppUser : IdentityUser
    {



        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Active { get; set; }

        public string DisplayName { get; set; }
        public Address Address { get; set; }
    }
}
