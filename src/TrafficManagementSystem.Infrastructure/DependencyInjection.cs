using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficManagementSystem.Application.Interfaces;
using TrafficManagementSystem.Application.Interfaces.Services;
using TrafficManagementSystem.Application.Services;
using TrafficManagementSystem.Application.Wrappers;
using TrafficManagementSystem.Domain.Settings;
using TrafficManagementSystem.Infrastructure.DbContexts;
using TrafficManagementSystem.Infrastructure.Identity;
using TrafficManagementSystem.Infrastructure.Persistence;

namespace TrafficManagementSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            //var connectionString = configuration.GetConnectionString("ApplicationDbConnectionString");

            var useSQLLite = configuration.GetValue<bool>("Settings:UseSQLLiteForMigration");
            //var useSQLLiteBoolean = bool.Parse(useSQLLite);
            if (useSQLLite)
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

            services.AddDbContext<AppIdentityDbContext>(
                options => options.UseSqlite(configuration.GetConnectionString("IdentityConnection")));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<TrafficManagementSystemDbContext>());

            services.AddScoped<IRepositoryProvider, RepositoryProvider>();

            services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));

            var key = Encoding.ASCII.GetBytes(configuration["JWTSettings:SecretKey"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

                x.Events = new JwtBearerEvents()
                {
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        return context.Response.WriteAsJsonAsync(new Response<string>(context.Error) { Messages = new List<string> { context.ErrorDescription } });
                    },

                    OnForbidden = context =>
                    {
                        context.Response.StatusCode = 403;
                        context.Response.ContentType = "application/json";
                        return context.Response.WriteAsJsonAsync(new Response<string>("Unathorized access denied."));
                    }
                };
            });

        }
    }
}
