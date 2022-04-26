using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficManagementSystem.Application.DTOs.Offence;
using TrafficManagementSystem.Application.Wrappers;

namespace TrafficManagementSystem.Application.Interfaces.Services
{
    public interface IOffenceService
    {
        Task<Response<OffenceDto>> AddOffenceAsync(NewOffenceRequest request);
        Task<Response<OffenceDto>> GetOffenceById(Guid id);
        Task<Response<IEnumerable<OffenceDto>>> GetAllOffences();
        Task DeleteOffenceAsync(Guid id);
    }
}
