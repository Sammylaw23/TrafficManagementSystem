using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficManagementSystem.Application.DTOs.Vehicle;
using TrafficManagementSystem.Application.Wrappers;

namespace TrafficManagementSystem.Application.Interfaces.Services
{
    public interface IVehicleService
    {
        Task<Response<VehicleDto>> AddVehicleAsync(NewVehicleRequest request);
        Task<Response<VehicleDto>> GetVehicleById(Guid id);
        Task<Response<IEnumerable<VehicleDto>>> GetAllVehicles();
        Task DeleteVehicleAsync(Guid id);
    }
}
