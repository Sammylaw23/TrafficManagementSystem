﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficManagementSystem.Domain.Entities
{
    public class Offence : BaseEntity
    {
        public int OffenceTypeId { get; set; }
        public string? OffenderName { get; set; }
        public string? PlateNumber { get; set; }
        public string? LicenseNo { get; set; }
        public int CreatedBy { get; set; }
        public DateTimeOffset ReportDate { get; set; }
    }
}