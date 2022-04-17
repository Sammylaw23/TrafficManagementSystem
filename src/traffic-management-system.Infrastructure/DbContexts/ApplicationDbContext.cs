using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using traffic_management_system.Domain.Entities;

namespace traffic_management_system.Infrastructure.DbContexts
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Offence_Type> Offence_Types { get; set; }
        public DbSet<Offence> Offences { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        //public DbSet<User> Users { get; set; }

        
    }
}
