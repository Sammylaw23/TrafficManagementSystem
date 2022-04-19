using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace traffic_management_system.Domain.Entities
{
    public class Vehicle
    {
        public string Name { get; set; }       
        public string Model { get; set; }
        public string Type { get; set; }
        public string Colour { get; set; }
        public string Brand { get; set; }
        public string PlateNumber { get; set; }
        public string EngineNumber { get; set; }
        public string ChassisNo { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }
        public string Owner { get; set; }

    }
}
