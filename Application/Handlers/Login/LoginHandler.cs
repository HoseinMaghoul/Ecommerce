using Application.Failures;
using Application.Queries.User;
using Application.Results.Login;
using Domain.IServices;
using MediatR;
using OneOf;

namespace Application.Handlers.Login;


public class LoginHandler : IRequestHandler<LoginQuery, OneOf<LoginResult, LoginFailure>>
{
    private readonly ILoginService loginService;
    private readonly IUserService userService;
    public LoginHandler(ILoginService loginService, IUserService userService)
    {
        this.loginService = loginService;
        this.userService = userService;
    }
    public async Task<OneOf<LoginResult, LoginFailure>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await loginService.GetUserSummaryAsync(request.Username);
        if (user is null || user.Salt is null || user.Password is null) {
            return new UserNameOrPasswordIsInvalid();
        }
        var passwordMatch = loginService.CheckPasswordValidationAsync(request.Password, user.Salt, user.Password);
        if (!passwordMatch) {
            return new UserNameOrPasswordIsInvalid();
        }
        var token = loginService.CreateToken(user.Id, request.PlatformType, request.IP, user.Roles);
        // var userDepartments = await userService.GetUserDepartmentsAsync(user.Id);
        return new LoginResult(token);
    }
}