using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficManagementSystem.Application.Interfaces.Repositories;

namespace TrafficManagementSystem.Application.Interfaces
{
    public interface IRepositoryProvider
    {
        IDriverRepository DriverRepository { get; }
        IOffenceRepository OffenceRepository { get; }
        IOffenceTypeRepository OffenceTypeRepository { get; }
        IUserRepository UserRepository { get; }
        IVehicleRepository VehicleRepository { get; }

        Task SaveChangesAsync();
    }
}
