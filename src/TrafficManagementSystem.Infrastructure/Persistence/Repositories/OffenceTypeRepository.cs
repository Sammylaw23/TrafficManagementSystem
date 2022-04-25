using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficManagementSystem.Application.Interfaces;
using TrafficManagementSystem.Application.Interfaces.Repositories;
using TrafficManagementSystem.Domain.Entities;

namespace TrafficManagementSystem.Infrastructure.Persistence.Repositories
{
    public class OffenceTypeRepository: RepositoryBase<OffenceType>, IOffenceTypeRepository
    {
        public OffenceTypeRepository(IApplicationDbContext context) : base(context)
        {
        }

        public async Task AddOffenceTypeAsync(OffenceType offenceType) => await AddAsync(offenceType);

        public async Task<OffenceType> GetOffenceTypeAsync(Guid id) => await GetByIdAsync(id);

        public async Task<IEnumerable<OffenceType>> GetOffenceTypesAsync() => await Get().ToListAsync();

        public void UpdateOffenceType(OffenceType offenceType) => Update(offenceType);
    }
}
