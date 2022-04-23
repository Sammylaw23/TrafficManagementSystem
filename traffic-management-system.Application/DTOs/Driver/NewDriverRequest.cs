﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace traffic_management_system.Application.DTOs.Driver
{
    public class NewDriverRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? LicenseNo { get; set; }
        public char Gender { get; set; }
    }
}
