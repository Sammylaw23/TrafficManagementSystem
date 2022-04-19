using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace traffic_management_system.Application.Interfaces
{
    public interface IRepositoryProvider
    {
        public IDriverRepository DriverRepository { get; }
        Task SaveChangesAsync();
    }
}
