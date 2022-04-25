using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficManagementSystem.Application.DTOs.Driver;
using TrafficManagementSystem.Domain.Entities;

namespace TrafficManagementSystem.Application.Interfaces.Services
{
    public interface IDriverService
    {
       Task<DriverDto> AddDriverAsync(NewDriverRequest request);
    }
}
