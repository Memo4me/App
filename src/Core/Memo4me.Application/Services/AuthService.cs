using System.Security.Cryptography;
using System.Text;
using Memo4me.Application.Interfaces.Repositories;
using Memo4me.Application.Interfaces.Services;
using Memo4me.Domain.Entities;

namespace Memo4me.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<bool> RegisterAsync(string username, string email, string password)
    {
        var salt = GenerateSalt();
        var passwordHash = HashPassword(password, salt);
        
        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = username,
            Email = email,
            PasswordHash = passwordHash,
            Salt = salt,
            CreatedAt = DateTime.UtcNow
        };

        await _userRepository.AddUserAsync(user);
        return true;
    }

    public async Task<User> LoginAsync(string username, string password)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username);

        var passwordHash = HashPassword(password, user.Salt);
        if (passwordHash == user.PasswordHash)
        {
            return user;
        }

        return null;
    }
    
    private static string GenerateSalt()
    {
        var saltBytes = new byte[16];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(saltBytes);
        }
        return Convert.ToBase64String(saltBytes);
    }

    private static string HashPassword(string password, string salt)
    {
        var saltedPassword = $"{salt}{password}";
        var saltedPasswordBytes = Encoding.UTF8.GetBytes(saltedPassword);
        return Convert.ToBase64String(SHA256.HashData(saltedPasswordBytes));
    }
}