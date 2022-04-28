using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficManagementSystem.Application.DTOs.Offence;
using TrafficManagementSystem.Application.DTOs.OffenceType;
using TrafficManagementSystem.Application.Wrappers;

namespace TrafficManagementSystem.Application.Interfaces.Services
{
    public interface IOffenceTypeService
    {
        Task<Response<OffenceTypeDto>> AddOffenceTypeAsync(NewOffenceTypeRequest request);
        Task<Response<OffenceTypeDto>> GetOffenceTypeById(Guid id);
        Task<Response<IEnumerable<OffenceTypeDto>>> GetAllOffenceTypes();
        Task DeleteOffenceTypeAsync(Guid id);

        Task<Response<IEnumerable<string>>> GetOffenceTypeCodes();

        
    }
}
