using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using traffic_management_system.Application.Interfaces;
using traffic_management_system.Infrastructure.Persistence.Repositories;

namespace traffic_management_system.Infrastructure.Persistence
{
    public class RepositoryProvider: IRepositoryProvider
    {
        private readonly IApplicationDbContext _dbContext;
        private IDriverRepository _driverRepository;
        public RepositoryProvider(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IDriverRepository DriverRepository => _driverRepository ??= new DriverRepository(_dbContext);

        public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

    }
}
