using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using traffic_management_system.Application.DTOs.Driver;
using traffic_management_system.Domain.Entities;

namespace traffic_management_system.Application.Interfaces.Services
{
    public interface IDriverService
    {
       Task<DriverDto> AddDriverAsync(NewDriverRequest request);
    }
}
