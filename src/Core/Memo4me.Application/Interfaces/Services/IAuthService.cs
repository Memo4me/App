using Memo4me.Domain.Entities;

namespace Memo4me.Application.Interfaces.Services;

public interface IAuthService
{
    Task<bool> RegisterAsync(string username, string email, string password);
    Task<User> LoginAsync(string username, string password);
}