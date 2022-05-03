using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrafficManagementSystem.Application.Interfaces;
using TrafficManagementSystem.Domain.Entities;
using TrafficManagementSystem.Infrastructure.Models;

namespace TrafficManagementSystem.Infrastructure.DbContexts
{
    public class TrafficManagementSystemDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public TrafficManagementSystemDbContext(DbContextOptions<TrafficManagementSystemDbContext> options) : base(options)
        {
        }
       
        public DbSet<Driver>? Drivers { get; set; }
        public DbSet<OffenceType>? OffenceTypes { get; set; }
        public DbSet<Offence>? Offences { get; set; }
        public DbSet<Vehicle>? Vehicles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var offenceType = modelBuilder.Entity<OffenceType>();
            offenceType.Property(x => x.FineAmount).HasPrecision(10, 3);

            base.OnModelCreating(modelBuilder);
        }
    }
}
