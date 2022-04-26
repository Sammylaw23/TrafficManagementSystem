using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficManagementSystem.Domain.Entities
{
    public class Offence : BaseEntity
    {
        
        //public Guid OffenceTypeId { get; set; } //I don't think it is needed. I think OffenceTypeCode can be used instead
        public string? OffenceTypeCode { get; set; }
        public string? OffenderName { get; set; }
        public string? PlateNumber { get; set; }
        public string? LicenseNo { get; set; }
        public string? CreatedBy { get; set; }
        public DateTimeOffset ReportDate { get; set; } = DateTimeOffset.Now;
    }
}
