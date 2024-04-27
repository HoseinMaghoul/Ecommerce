using Domain.DTOs;
using Domain.Enums;

namespace Domain.IServices;


public interface ILoginService
{
    public Task<UserNameWithPasswordDTO?> GetUserSummaryAsync(string userName);
    public bool CheckPasswordValidationAsync(string password, string salt, string hash);
    public string CreateToken(long userID, PlatformType platform, string ip, List<Role> roles);

    
}