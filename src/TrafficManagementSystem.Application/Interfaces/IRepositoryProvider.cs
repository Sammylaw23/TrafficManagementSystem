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
