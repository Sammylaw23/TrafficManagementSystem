using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficManagementSystem.UI.Infrastructure.Authentication;
using TrafficManagementSystem.UI.Infrastructure.Managers;

namespace TrafficManagementSystem.UI.Infrastructure
{
    public static class DependencyInjection
    {
        public static WebAssemblyHostBuilder AddClientServices(this WebAssemblyHostBuilder builder)
        {
            builder.Services
                .AddOptions()
                .AddAuthorizationCore()
                 //.AddLocalization(options => options.ResourcesPath = "Resources")
                .AddMudServices()
                .AddBlazoredLocalStorage()
                .AddScoped<AuthenticationStateProvider, AppStateProvider>()
                //.AddTransient<IAuthenticationManager, AuthenticationManager>()
                .AddManagers();

            return builder;
        }

        public static IServiceCollection AddManagers(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticationManager, AuthenticationManager>();
            services.AddTransient<IDriverManager, DriverManager>();
            //services.AddTransient<IWalletManager, WalletManager>();
            //services.AddTransient<ICurrencyManager, CurrencyManager>();
            //services.AddTransient<ITransactionManager, TransactionManager>();
            //services.AddSingleton<ApplicationStateManager>();

            return services;
        }
    }

}
