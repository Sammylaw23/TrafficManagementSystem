using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using traffic_management_system.Application.Interfaces;
using traffic_management_system.Application.Interfaces.Repositories;
using traffic_management_system.Domain.Entities;

namespace traffic_management_system.Infrastructure.Persistence.Repositories
{
    public class VehicleRepository :RepositoryBase<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(IApplicationDbContext context) : base(context)
        {

        }


        public async Task AddVehicleAsync(Vehicle vehicle) => await AddAsync(vehicle);

        public async Task<Vehicle> GetVehicleAsync(Guid id) => await GetByIdAsync(id);

        public async Task<IEnumerable<Vehicle>> GetVehiclesAsync() => await Get().ToListAsync();

        public void UpdateVehicle(Vehicle vehicle) => Update(vehicle);
    }
}


