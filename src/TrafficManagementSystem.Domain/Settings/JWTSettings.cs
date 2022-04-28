using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficManagementSystem.Domain.Settings
{
    public class JWTSettings
    {
        public string SecretKey { get; set; }
        public int DurationInMinutes { get; set; }
    }
}
