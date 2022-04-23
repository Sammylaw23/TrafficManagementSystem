using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using traffic_management_system.Application.Interfaces;
using traffic_management_system.Application.Interfaces.Repositories;
using traffic_management_system.Domain.Entities;

namespace traffic_management_system.Infrastructure.Persistence.Repositories
{
    public class UserRepository: RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IApplicationDbContext context) : base(context)
        {
        }

        public async Task AddUserAsync(User user) => await AddAsync(user);

        public async Task<User> GetUserAsync(Guid id) => await GetByIdAsync(id);

        public async Task<IEnumerable<User>> GetUsersAsync() => await Get().ToListAsync();

        public void UpdateUser(User user) => Update(user);
    }
}
