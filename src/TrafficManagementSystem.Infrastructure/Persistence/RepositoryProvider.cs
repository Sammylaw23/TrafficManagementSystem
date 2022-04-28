﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficManagementSystem.Application.Interfaces;
using TrafficManagementSystem.Application.Interfaces.Repositories;
using TrafficManagementSystem.Infrastructure.Persistence.Repositories;

namespace TrafficManagementSystem.Infrastructure.Persistence
{

    public class RepositoryProvider : IRepositoryProvider
    {
        private readonly IApplicationDbContext _dbContext;
        private IDriverRepository _driverRepository;
        private IVehicleRepository _vehicleRepository;
        private IOffenceRepository _offenceRepository;
        private IOffenceTypeRepository _offenceTypeRepository;
        private IUserRepository _userRepository;
        public RepositoryProvider(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IDriverRepository DriverRepository => _driverRepository ??= new DriverRepository(_dbContext);
        public IVehicleRepository VehicleRepository => _vehicleRepository ??= new VehicleRepository(_dbContext);
        public IOffenceRepository OffenceRepository => _offenceRepository ??= new OffenceRepository(_dbContext);
        public IOffenceTypeRepository OffenceTypeRepository
            => _offenceTypeRepository ??= new OffenceTypeRepository(_dbContext);
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_dbContext);

        public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

    }
}
