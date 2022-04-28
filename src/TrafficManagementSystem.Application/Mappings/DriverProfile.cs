using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficManagementSystem.Application.DTOs.Driver;
using TrafficManagementSystem.Domain.Entities;

namespace TrafficManagementSystem.Application.Mappings
{
    public class DriverProfile: Profile
    {
        public DriverProfile()
        {
            CreateMap<NewDriverRequest, Driver>();
            CreateMap<Driver, DriverDto>();
        }

    }
}
