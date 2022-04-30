using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficManagementSystem.Domain.Entities;

namespace TrafficManagementSystem.Application.Interfaces.Repositories
{
    public interface IOffenceTypeRepository
    {
        Task AddOffenceTypeAsync(OffenceType offence);
        void UpdateOffenceType(OffenceType offence);
        Task<OffenceType> GetOffenceTypeByIdAsync(Guid id);
        Task<IEnumerable<OffenceType>> GetOffenceTypesAsync();
        void DeleteOffenceType(OffenceType offence);
        Task<OffenceType> GetOffenceTypeByCodeAsync(string code);
        Task<IEnumerable<string>> GetOffenceTypeCodes();

       
    }
}
