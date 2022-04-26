using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficManagementSystem.Application.Interfaces;
using TrafficManagementSystem.Domain.Entities;

namespace TrafficManagementSystem.Infrastructure.DbContexts
{
    public class TrafficManagementSystemDbContext : DbContext, /*IdentityDbContext,*/ IApplicationDbContext
    {
        public TrafficManagementSystemDbContext(DbContextOptions<TrafficManagementSystemDbContext> options) 
            : base(options)
        {
        }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<OffenceType> OffenceTypes { get; set; }
        public DbSet<Offence> Offences { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        //public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var offenceType = modelBuilder.Entity<OffenceType>();
            offenceType.Property(x=>x.FineAmount).HasPrecision(18,3);
        }
    }
}
