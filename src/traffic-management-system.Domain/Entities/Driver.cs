using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace traffic_management_system.Domain.Entities
{
    public class Driver
    {
        public string Name { get; set; }
        public DateTimeOffset DOB { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string LicenseNo { get; set; }
        public char Gender { get; set; }
    }
}
