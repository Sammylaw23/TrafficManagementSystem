using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficManagementSystem.Domain.Entities;

namespace TrafficManagementSystem.Application.Interfaces.Repositories
{
    public interface IOffenceRepository
    {
        Task AddOffenceAsync(Offence offence);
        void UpdateOffence(Offence offence);
        Task<Offence> GetOffenceAsync(Guid id);
        Task<IEnumerable<Offence>> GetOffencesAsync();
    }
}
