﻿using Microsoft.EntityFrameworkCore;
using TrafficManagementSystem.Application.Interfaces;
using TrafficManagementSystem.Application.Interfaces.Repositories;
using TrafficManagementSystem.Domain.Entities;

namespace TrafficManagementSystem.Infrastructure.Persistence.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
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
