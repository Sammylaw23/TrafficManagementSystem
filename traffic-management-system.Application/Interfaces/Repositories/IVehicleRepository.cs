using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using traffic_management_system.Domain.Entities;

namespace traffic_management_system.Application.Interfaces.Repositories
{
    public interface IVehicleRepository
    {
        Task AddVehicleAsync(Vehicle vehicle);
        void UpdateVehicle(Vehicle vehicle);
        Task<Vehicle> GetVehicleAsync(Guid id);
        Task<IEnumerable<Vehicle>> GetVehiclesAsync();
    }
}
