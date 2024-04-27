using Domain.Enums;


namespace API.Contract.Login;
/// <summary>
/// Login with username and password request
/// </summary>
/// <param name="UserName"></param>
/// <param name="Password"></param>
/// <param name="PlatformType"></param>

public record LoginRequest(
    string UserName,
    string Password,
    PlatformType PlatformType
);