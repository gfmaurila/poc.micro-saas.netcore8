using API.External.MKT.Database.DTO;
using API.External.MKT.Database.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.External.MKT.Controller;

// CRUD for User-Role Binding
[ApiController]
[Route("api/user-roles")]
public class UserRoleController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserRoleController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost("assign")]
    public async Task<IActionResult> AssignRole([FromBody] UserRoleDto model)
    {
        var user = await _userManager.FindByIdAsync(model.UserId);
        if (user == null)
        {
            return NotFound("User not found.");
        }

        var result = await _userManager.AddToRoleAsync(user, model.RoleName);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return Ok();
    }

    // Add more CRUD endpoints for managing user-role relationships
}
