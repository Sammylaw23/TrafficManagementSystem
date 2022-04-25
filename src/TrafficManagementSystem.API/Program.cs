using TrafficManagementSystem.Application.Interfaces;
using TrafficManagementSystem.Application.Interfaces.Services;
using TrafficManagementSystem.Application.Services;
using TrafficManagementSystem.Infrastructure;
using TrafficManagementSystem.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddInfrastructure(builder.Configuration);
//builder.Services.AddDbContext<TrafficManagementSystemDbContext>(options =>
//    options.UseSqlServer(connectionString));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
