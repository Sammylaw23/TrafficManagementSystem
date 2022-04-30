using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficManagementSystem.Domain.Entities.Identity;

namespace TrafficManagementSystem.Infrastructure.Identity
{
    public static class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser()
                {
                    DisplayName = "Andrew Adigun",
                    Email = "andrew@gmail",
                    UserName = "andrew@gmail",
                    Address = new Address()
                    {
                        FirstName = "Adeola",
                        LastName = "Odeku",
                        Street = "No 10 Odeku",
                        City = "Lagos",
                        State = "Lagos",
                        ZipCode = "234"
                    }
                };

                await userManager.CreateAsync(user,"Pa$$w0rd");
            }
        }
    }
}
