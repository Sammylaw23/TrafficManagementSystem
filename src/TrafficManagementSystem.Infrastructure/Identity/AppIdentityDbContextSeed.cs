using Microsoft.AspNetCore.Identity;
using TrafficManagementSystem.Infrastructure.Models;

namespace TrafficManagementSystem.Infrastructure.Identity
{
    public static class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser
                {
                    FirstName = "Adeola",
                    LastName = "Odeku",
                    Email = "andrew@gmail.com",
                    UserName = "andrew",
                    Address ="No 10 Odeku,Lagos",
                    EmailConfirmed=true,
                    
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}
