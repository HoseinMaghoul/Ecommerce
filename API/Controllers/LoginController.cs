using Application.Queries.User;
using Application.Results.Login;
using API.Contract.Login;
using Application.Failures;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using API.Controllers;

namespace CorrespondenceSystem.Controllers;
/// <summary>
/// LoginController
/// </summary>
public class LoginController : BaseController
{
   
    private readonly IMediator mediator;
    /// <summary>
    /// Initializes a new instance of the <see cref="LoginController"/> class.
    /// </summary>
    /// <param name="mediator"></param>
    public LoginController(IMediator mediator) => this.mediator = mediator;

    /// <summary>
    /// API for login. If the username or password is invalid, it will return a failure with code 1 and if else return a token
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("/Users/Login")]
    [ProducesResponseType(typeof(LoginResult), 200)]
    [ProducesResponseType(typeof(LoginFailure), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var result = await mediator.Send(new LoginQuery(request.UserName, request.Password, GetSourceIpAddress(), request.PlatformType));
        if (result.IsT1)
        {
            return BadRequest(result.AsT1);
        }
        else
        {
            return Ok(result.AsT0);
        }

    }

    
}