using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace traffic_management_system.Domain.Entities
{
    public class Offence
    {
        public int Offence_TypeId { get; set; }
        public string Offender_Name { get; set; }
        public string PlateNumber { get; set; }
        public string LicenseNo { get; set; }
        public int CreatedBy { get; set; }
        public DateTimeOffset ReportDate { get; set; }
    }
}
