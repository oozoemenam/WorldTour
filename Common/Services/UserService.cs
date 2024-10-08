using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WorldTour.Common.Helpers;
using WorldTour.Common.Interfaces;
using WorldTour.Dtos;
using WorldTour.Models;

namespace WorldTour.Common.Services;

public class UserService : IUserService
{
    private readonly List<User?> _users = new List<User?>
    {
        new User
        {
            Id = 1,
            FirstName = "Coolname",
            LastName = "Dopesurname",
            Username = "randomusername",
            Password = "strongpassword"
        }
    };

    private readonly AuthSettings _authSettings;

    public UserService(IOptions<AuthSettings> appSettings) => _authSettings = appSettings.Value;

    public AuthenticateResponse? Authenticate(AuthenticateRequest model)
    {
        var user = _users.SingleOrDefault(u => u.Username == model.Username && u.Password == model.Password);
        if (user == null) return null;
        var token = GenerateToken(user);
        return new AuthenticateResponse(user, token);
    }

    public User? GetById(int id) => _users.FirstOrDefault(u => u.Id == id);

    private string GenerateToken(User user)
    {
        byte[] key = Encoding.ASCII.GetBytes(_authSettings.Secret!);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}