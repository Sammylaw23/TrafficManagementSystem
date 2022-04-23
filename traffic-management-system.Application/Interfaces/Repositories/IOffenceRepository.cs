using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using traffic_management_system.Domain.Entities;

namespace traffic_management_system.Application.Interfaces.Repositories
{
    public interface IOffenceRepository
    {
        Task AddOffenceAsync(Offence offence);
        void UpdateOffence(Offence offence);
        Task<Offence> GetOffenceAsync(Guid id);
        Task<IEnumerable<Offence>> GetOffencesAsync();
    }
}
