namespace API.External.MKT.Database.DTO;

public class LoginDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class RegisterDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}

public class UserRoleDto
{
    public string UserId { get; set; }
    public string RoleName { get; set; }
}
