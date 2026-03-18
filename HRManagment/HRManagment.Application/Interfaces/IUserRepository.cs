using HRManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagment.Application.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User?> GetByIdAsync(Guid id);
        Task<List<User>> GetAllAsync();
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
        Task<bool> IsEmailExistsAsync(string email);
    }
}
