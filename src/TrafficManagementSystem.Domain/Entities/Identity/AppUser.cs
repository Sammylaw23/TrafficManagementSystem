using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficManagementSystem.Domain.Entities.Identity
{
    public class AppUser: IdentityUser
    {



        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Active { get; set; }

        public string DisplayName { get; set; }
        public Address Address { get; set; }
    }
}
