using Memo4me.API.Models;
using Memo4me.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Memo4me.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _authService.RegisterAsync(request.Username, request.Email, request.Password);
        if (!result)
        {
            return BadRequest("Username or email is already taken.");
        }

        return Ok("User registered successfully.");
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _authService.LoginAsync(request.Username, request.Password);
        if (user == null)
        {
            return Unauthorized("Invalid username or password.");
        }
        
        return Ok(new { user.Id, user.Username, user.Email });
    }
}