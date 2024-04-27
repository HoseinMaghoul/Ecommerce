using Domain.DTOs;
using Domain.Enums;

namespace Domain.IServices;

public interface IUserService
{
	Task CreateFirstUser(string userName, string password);
	Task<bool> CheckUserExist();

	
}
