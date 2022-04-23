using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using traffic_management_system.Application.Interfaces.Repositories;

namespace traffic_management_system.Application.Interfaces
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
