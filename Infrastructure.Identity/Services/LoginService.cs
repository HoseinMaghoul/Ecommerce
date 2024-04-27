using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Domain.DTOs;
using Domain.Enums;
using Domain.IServices;
using Infrastructure.DBContext;
using Infrastructure.Identity.Configs;
using Infrastrucutre.Shared.HashAndEncryption;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Identity.Services;
public class LoginService : ILoginService
{
    private readonly ProjectDbContext context;
    private readonly JwtSettings jwtSettings;

    public LoginService(ProjectDbContext context, JwtSettings jwtOptions)
    {
        this.context = context;
        this.jwtSettings = jwtOptions;
    }

    public async Task<UserNameWithPasswordDTO?> GetUserSummaryAsync(string userName)
    {
        var user = await context.Users.Where(x => x.UserName == userName).Select(x => new UserNameWithPasswordDTO()
        {
            UserName = x.UserName,
            Password = x.Password,
            Id = x.ID,
            Salt = x.Salt
        }).FirstOrDefaultAsync();
        if (user != null)
        {
            var roles = context.UserRoles.Where(x => x.UserId == user.Id).Select(x => x.RoleId).ToList();
            user.Roles = roles.Select(ur => Enum.GetValues<Role>().Where(e => (int)e == ur).FirstOrDefault()).ToList();
        }
        return user;
    }

    public bool CheckPasswordValidationAsync(string password, string salt, string hash)
    {
        return HashFunctions.VerifyPassword(password + salt, hash);
    }

    public string CreateToken(long userID, PlatformType platform, string ip, List<Role> roles)
    {
       
        var signingCredential = new SigningCredentials(
        new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtSettings.Secret)),

        SecurityAlgorithms.HmacSha256);

        var Claims = new[]
              {
                new Claim(JwtRegisteredClaimNames.Sub, userID.ToString()),
        }.ToList();

        for (var i = 0; i < roles.Count; i++)
        {
            Claims.Add(new Claim(ClaimTypes.Role, ((int)roles[i]).ToString()));
        }



        var securityToken = new JwtSecurityToken(
            issuer: jwtSettings.Issuer,
            audience: jwtSettings.Audience,
            expires: DateTime.UtcNow.AddDays(jwtSettings.ExpiryDays),
            claims: Claims,
            signingCredentials: signingCredential);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);


    }
}