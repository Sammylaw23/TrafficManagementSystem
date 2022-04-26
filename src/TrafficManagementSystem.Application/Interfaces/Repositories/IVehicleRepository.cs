using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficManagementSystem.Domain.Entities;

namespace TrafficManagementSystem.Application.Interfaces.Repositories
{
    public interface IVehicleRepository
    {
        Task AddVehicleAsync(Vehicle vehicle);
        void UpdateVehicle(Vehicle vehicle);
        Task<Vehicle> GetVehicleByIdAsync(Guid id);
        Task<IEnumerable<Vehicle>> GetVehiclesAsync();
        void DeleteVehicle(Vehicle vehicle);
        Task<Vehicle> GetVehicleByPlateNumberAsync(string plateNumber);
        Task<bool> VehicleExists(Vehicle vehicle);

        


    }
}
