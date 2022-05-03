using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TrafficManagementSystem.UI;
using MudBlazor.Services;
using Blazored.LocalStorage;
using TrafficManagementSystem.UI.Infrastructure.Authentication;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.Authorization;
using TrafficManagementSystem.UI.Infrastructure.Managers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddTransient<AuthenticationHeaderHandler>()
                .AddScoped(sp => sp
                    .GetRequiredService<IHttpClientFactory>()
                    .CreateClient("TMS.API"))
                .AddHttpClient("TMS.API", client => client.BaseAddress = new Uri(builder.Configuration["ApiUrl"] + "/api/"))
                .AddHttpMessageHandler<AuthenticationHeaderHandler>();
builder.Services.AddHttpClientInterceptor();
builder.Services.AddScoped<AuthenticationStateProvider, AppStateProvider>();
builder.Services.AddTransient<IAuthenticationManager, AuthenticationManager>();

await builder.Build().RunAsync();
