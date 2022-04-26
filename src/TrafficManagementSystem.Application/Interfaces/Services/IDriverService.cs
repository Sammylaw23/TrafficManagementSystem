﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficManagementSystem.Application.DTOs.Driver;
using TrafficManagementSystem.Application.Wrappers;

namespace TrafficManagementSystem.Application.Interfaces.Services
{
    public interface IDriverService
    {
       Task<Response<DriverDto>> AddDriverAsync(NewDriverRequest request);
        Task<Response<DriverDto>> GetDriverById(Guid id);
        Task<Response<IEnumerable<DriverDto>>> GetAllDrivers();
        Task DeleteDriverAsync(Guid id);

    }
}
