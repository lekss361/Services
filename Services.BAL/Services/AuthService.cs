namespace Services.BAL.Services;

using global::Services.BAL.Configuration;
using global::Services.BAL.Helpers;
using global::Services.DAL;
using global::Services.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

public class AuthService : IAuthService
{

    private readonly IDbRepository _repository;

    public AuthService(IDbRepository repository)
    {
        _repository = repository;
    }

    public string Login(int id, string password)
    {
        var user = _repository.Get<UserDto>().FirstOrDefault(x => x.Id == id);
        if (user == null)
            throw new NullReferenceException($"User with login {id} was not found.");

        if (!SecurePasswordHasher.Verify(password, user.PasswordHash))
            throw new AuthenticationException("Password is not correct for this user.");

        var claims = new List<Claim>
        {
            new(ClaimTypes.UserData, user.Id.ToString()),
            new(ClaimTypes.Name, user.Name),
            new(ClaimTypes.Role, user.Role.ToString())
        };

        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.Issuer,
            audience: AuthOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(30)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}
