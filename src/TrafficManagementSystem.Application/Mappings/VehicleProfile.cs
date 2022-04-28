using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficManagementSystem.Application.DTOs.Vehicle;
using TrafficManagementSystem.Domain.Entities;

namespace TrafficManagementSystem.Application.Mappings
{
    public class VehicleProfile: Profile
    {
        public VehicleProfile()
        {
            CreateMap<NewVehicleRequest, Vehicle>();
            CreateMap<Vehicle, VehicleDto>();
        }
    }
}
