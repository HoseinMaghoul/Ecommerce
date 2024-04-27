namespace API.Contract.User;
/// <summary>
/// Create first user request. It works only when there is no user .
/// </summary>
/// <param name="UserName"></param>
/// <param name="Password"></param>
public record CreateFirstUserRequest(string UserName, string Password);
