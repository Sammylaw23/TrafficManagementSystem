﻿using TrafficManagementSystem.Domain.Entities;

namespace TrafficManagementSystem.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        void UpdateUser(User user);
        Task<User> GetUserAsync(Guid id);
        Task<IEnumerable<User>> GetUsersAsync();
    }
}
