using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace traffic_management_system.Domain.Entities
{
    public class OffenceType : BaseEntity
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public Int16 Point { get; set; }
        public string? Category { get; set; }
        public decimal FineAmount { get; set; }

    }
}
