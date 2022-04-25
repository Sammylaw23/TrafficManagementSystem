using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficManagementSystem.Application.Interfaces;
using TrafficManagementSystem.Application.Interfaces.Services;
using TrafficManagementSystem.Application.Services;
using TrafficManagementSystem.Infrastructure.DbContexts;
using TrafficManagementSystem.Infrastructure.Persistence;

namespace TrafficManagementSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            //var connectionString = configuration.GetConnectionString("ApplicationDbConnectionString");

            var UseSQLLite = configuration.GetSection("Settings:UseSQLLiteForMigration").Value;
            var UseSQLLiteBoolean = bool.Parse(UseSQLLite);
            if (UseSQLLiteBoolean)
            {
                services.AddDbContext<TrafficManagementSystemDbContext>(
                   options => options.UseSqlite(connectionString,
                   x => x.MigrationsAssembly(typeof(TrafficManagementSystemDbContext).Assembly.FullName)));
            }
            else
            {
                services.AddDbContext<TrafficManagementSystemDbContext>(
                    options => options.UseSqlServer(connectionString,
                    x => x.MigrationsAssembly(typeof(TrafficManagementSystemDbContext).Assembly.FullName)));
            }

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<TrafficManagementSystemDbContext>());
            services.AddScoped<IRepositoryProvider, RepositoryProvider>();
            services.AddScoped<IDriverService, DriverService>();


        }
    }
}
