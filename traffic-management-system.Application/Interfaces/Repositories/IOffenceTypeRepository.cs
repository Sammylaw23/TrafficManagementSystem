using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using traffic_management_system.Domain.Entities;

namespace traffic_management_system.Application.Interfaces.Repositories
{
    public interface IOffenceTypeRepository
    {
        Task AddOffenceTypeAsync(OffenceType offence);
        void UpdateOffenceType(OffenceType offence);
        Task<OffenceType> GetOffenceTypeAsync(Guid id);
        Task<IEnumerable<OffenceType>> GetOffenceTypesAsync();
    }
}
