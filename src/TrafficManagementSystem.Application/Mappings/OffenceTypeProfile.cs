using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficManagementSystem.Application.DTOs.OffenceType;
using TrafficManagementSystem.Domain.Entities;

namespace TrafficManagementSystem.Application.Mappings
{
    public class OffenceTypeProfile : Profile
    {
        public OffenceTypeProfile()
        {
            CreateMap<NewOffenceTypeRequest, OffenceType>();
            CreateMap<OffenceType, OffenceTypeDto>();
        }
    }
}
