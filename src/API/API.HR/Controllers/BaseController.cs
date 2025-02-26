using Bogus;
using Microsoft.AspNetCore.Mvc;

namespace API.HR.Controllers;

[ApiController]
public abstract partial class BaseController : ControllerBase
{
    protected Guid UserId { get; set; }
    protected string Email { get; set; }
    protected string User { get; set; }

    protected bool UserAutentication { get; set; }

    protected BaseController()
    {
        var faker = new Faker();
        UserId = Guid.NewGuid();
        Email = faker.Internet.Email();
        User = faker.Internet.UserName();
    }
}
