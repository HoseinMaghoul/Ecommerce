using System.Text;
using Domain.Entities;
using Domain.Enums;
using Domain.IServices;
using Infrastructure.DBContext;
using Infrastrucutre.Shared.HashAndEncryption;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services;

public class UserService : IUserService
{

    private readonly ProjectDbContext context;
	public UserService(ProjectDbContext context)
	{
		this.context = context;
	}
    public async Task<bool> CheckUserExist()
    {
        return await Task.FromResult(!context.Users.IsNullOrEmpty());
    }

    public async Task CreateFirstUser(string userName, string password)
    {
        UserEntity firstUser = new()
        {
            FirstName = "Admin",
            LastName = "Admin",
            IsActive = true,
            UserName = userName,
            Salt = RandomSaltGenerator()
        };

		var SaltPassword = password + firstUser.Salt;
		firstUser.Password = HashFunctions.HashPassword(SaltPassword!);
		await context.Users.AddAsync(firstUser);
		await context.SaveChangesAsync();
		await context.UserRoles.AddAsync(new UserRolesEntity()
		{
			UserId = firstUser.ID,
			RoleId = (int)Role.SupperAdmin,
		});
		await context.SaveChangesAsync();

        
    }


    public static string RandomSaltGenerator()
	{
		string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
		var random = new Random();
		var stringBuilder = new StringBuilder(20); ;
		for (int i = 0; i < 20; i++)
		{
			stringBuilder.Append(chars[random.Next(chars.Length)]);
		}
		return stringBuilder.ToString();
	}
}

