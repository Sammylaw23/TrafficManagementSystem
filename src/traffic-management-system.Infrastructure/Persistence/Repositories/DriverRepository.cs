using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using traffic_management_system.Application.Interfaces;
using traffic_management_system.Domain.Entities;

namespace traffic_management_system.Infrastructure.Persistence.Repositories
{
    public class DriverRepository: RepositoryBase<Driver>, IDriverRepository
    {
        public DriverRepository(IApplicationDbContext context) : base(context)
        {
        }

        public async Task AddDriverAsync(Driver driver) => await AddAsync(driver);

        public async Task<Driver> GetDriverAsync(Guid id) => await GetByIdAsync(id);

        public async Task<IEnumerable<Driver>> GetDriversAsync() => await _dbContext.Drivers.ToListAsync();

        public void UpdateDriver(Driver driver) => Update(driver);
    }
}
