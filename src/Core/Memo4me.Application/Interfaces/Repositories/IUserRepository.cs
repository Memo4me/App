using Memo4me.Domain.Entities;

namespace Memo4me.Application.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User> GetUserByUsernameAsync(string username);
    Task<User> GetUserByEmailAsync(string email);
    Task AddUserAsync(User user);
}