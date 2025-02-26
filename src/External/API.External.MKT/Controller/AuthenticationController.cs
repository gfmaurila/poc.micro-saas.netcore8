using API.External.MKT.Database;
using API.External.MKT.Database.DTO;
using API.External.MKT.Database.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.External.MKT.Controller;

// Define AuthenticationController
[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IConfiguration _configuration; // Adicione essa linha

    public AuthenticationController(
        UserManager<ApplicationUser> userManager,
        IJwtTokenService jwtTokenService,
        IConfiguration configuration) // Adicione esse parâmetro
    {
        _userManager = userManager;
        _jwtTokenService = jwtTokenService;
        _configuration = configuration; // Inicialize a variável
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto model)
    {
        var user = await _userManager.FindByNameAsync(model.Username);
        if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
        {
            return Unauthorized("Invalid credentials.");
        }

        var token = _jwtTokenService.GenerateJwtToken(user);
        var roles = await _userManager.GetRolesAsync(user);

        return Ok(new
        {
            Token = token,
            ExpiresIn = int.Parse(_configuration["Jwt:TIMEOUT"]),
            UserId = user.Id,
            Username = user.UserName,
            Roles = roles
        });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto model)
    {
        var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return Ok();
    }
}

