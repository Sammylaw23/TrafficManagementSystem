using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TrafficManagementSystem.Application.Interfaces;
using TrafficManagementSystem.Application.Interfaces.Services;
using TrafficManagementSystem.Application.Services;

namespace TrafficManagementSystem.Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IVehicleService,VehicleService>();
            services.AddScoped<IOffenceService, OffenceService>();
            services.AddScoped<IOffenceTypeService, OffenceTypeService>();
        } 
    }
}
