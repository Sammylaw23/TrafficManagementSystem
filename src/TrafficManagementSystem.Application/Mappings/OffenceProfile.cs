using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficManagementSystem.Application.DTOs.Offence;
using TrafficManagementSystem.Domain.Entities;

namespace TrafficManagementSystem.Application.Mappings
{
    public class OffenceProfile: Profile
    {
        public OffenceProfile()
        {
            CreateMap<NewOffenceRequest, Offence>();
            CreateMap<Offence, OffenceDto>();
        }
    }
}
