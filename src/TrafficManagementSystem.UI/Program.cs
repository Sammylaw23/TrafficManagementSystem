using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TrafficManagementSystem.UI;
using MudBlazor.Services;
using Blazored.LocalStorage;
using TrafficManagementSystem.UI.Infrastructure.Authentication;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.Authorization;
using TrafficManagementSystem.UI.Infrastructure.Managers;
using TrafficManagementSystem.UI.Infrastructure;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.AddClientServices();
builder.Services.AddTransient<AuthenticationHeaderHandler>()
                .AddScoped(sp => sp
                    .GetRequiredService<IHttpClientFactory>()
                    .CreateClient("TMS.API"))
                .AddHttpClient("TMS.API", client => client.BaseAddress = new Uri(builder.Configuration["ApiUrl"] + "/api/"))
                .AddHttpMessageHandler<AuthenticationHeaderHandler>();
builder.Services.AddHttpClientInterceptor();

await builder.Build().RunAsync();
