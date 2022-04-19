using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using traffic_management_system.Domain.Entities;

namespace traffic_management_system.Application.Interfaces
{
    public interface IDriverRepository
    {
        Task AddDriverAsync(Driver driver);
        void UpdateDriver(Driver product);
        Task<Driver> GetDriverAsync(Guid id);
        Task<IEnumerable<Driver>> GetDriversAsync();
    }
}
