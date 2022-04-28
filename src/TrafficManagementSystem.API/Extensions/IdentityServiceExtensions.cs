using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TrafficManagementSystem.Application.Wrappers;
using TrafficManagementSystem.Domain.Entities.Identity;
using TrafficManagementSystem.Domain.Settings;
using TrafficManagementSystem.Infrastructure.Identity;

namespace TrafficManagementSystem.API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,IConfiguration configuration)
        {
            var builder = services.AddIdentityCore<AppUser>();
            builder = new IdentityBuilder(builder.UserType, builder.Services);
            builder.AddEntityFrameworkStores<AppIdentityDbContext>();
            builder.AddSignInManager<SignInManager<AppUser>>();
                
         

            return services;
        }
    }
}
