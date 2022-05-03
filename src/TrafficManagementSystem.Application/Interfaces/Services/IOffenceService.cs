﻿using TrafficManagementSystem.Application.DTOs.Offence;
using TrafficManagementSystem.Application.Wrappers;

namespace TrafficManagementSystem.Application.Interfaces.Services
{
    public interface IOffenceService
    {
        Task AddOffenceAsync(NewOffenceRequest request);
        Task<Response<OffenceDto>> GetOffenceById(Guid id);
        Task<Response<IEnumerable<OffenceDto>>> GetAllOffences();
        Task DeleteOffenceAsync(Guid id);
    }
}
