using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using server.Utils;
using server.Models;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly SymphonyContext _context;

    public AuthController(IConfiguration configuration, SymphonyContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    [HttpPost("signin")]
    public IActionResult SignIn([FromBody] User user)
    {

        if (IsValidUser(user.Email, user.Password))
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email ?? ""),
                new Claim(ClaimTypes.Email, user.Email ?? "")
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"] ?? "")
            );
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: creds
            );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        return Unauthorized();
    }

    private bool IsValidUser(string? email, string? password)
    {
        if (email == null || password == null)
        {
            return false;
        }

        var user = _context.User.FirstOrDefault(u => u.Email == email);

        if (user == null)
        {
            return false;
        }

        var hashedPassword = PasswordUtils.EncryptPassword(password);

        return user.Password == hashedPassword;
    }
}
