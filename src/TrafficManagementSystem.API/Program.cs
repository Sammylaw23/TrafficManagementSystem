using TrafficManagementSystem.API.Extensions;
using TrafficManagementSystem.Application;
using TrafficManagementSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();


//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<TrafficManagementSystemDbContext>(options =>
//    options.UseSqlServer(connectionString));
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructure(builder.Configuration);









builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.



//using (var scope = app.Services.CreateScope())
//{
//    var serviceProvider = scope.ServiceProvider;
//    try
//    {
//        var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
//        var identityContext = serviceProvider.GetRequiredService<AppIdentityDbContext>();
//        await identityContext.Database.MigrateAsync();
//        await AppIdentityDbContextSeed.SeedUsersAsync(userManager);
//    }
//    catch (Exception ex)
//    {
//        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
//        logger.LogError(ex, "An error occurred during migration");
//    }
//}

//var userManager = app.Services.GetRequiredService<UserManager<AppUser>>();
//var identityContext = app.Services.GetRequiredService<AppIdentityDbContext>();
//await identityContext.Database.MigrateAsync();
//await AppIdentityDbContextSeed.SeedUsersAsync(userManager);



//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseApiErrorHandler();

app.MapControllers();

app.Run();
