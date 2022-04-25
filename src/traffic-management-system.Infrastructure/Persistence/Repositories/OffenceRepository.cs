﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using traffic_management_system.Application.Interfaces;
using traffic_management_system.Application.Interfaces.Repositories;
using traffic_management_system.Domain.Entities;

namespace traffic_management_system.Infrastructure.Persistence.Repositories
{
    public class OffenceRepository: RepositoryBase<Offence>, IOffenceRepository
    {
        public OffenceRepository(IApplicationDbContext context) : base(context)
        {
        }

        public async Task AddOffenceAsync(Offence offence) => await AddAsync(offence);

        public async Task<Offence> GetOffenceAsync(Guid id) => await GetByIdAsync(id);

        public async Task<IEnumerable<Offence>> GetOffencesAsync() => await Get().ToListAsync();

        public void UpdateOffence(Offence offence) => Update(offence);
    }
}