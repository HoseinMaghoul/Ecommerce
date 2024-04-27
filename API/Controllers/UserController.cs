using API.Contract.User;
using Application.Commands.User;
using Application.Queries.User;
using Application.Results;
using API.Contract;
// using API.Controllers;
using Application.Failures;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;


public class UserController : BaseController
{
    private readonly IMediator mediator;
	/// <summary>
	/// Initializes a new instance of the <see cref="UserController"/> class.
	/// </summary>
	/// <param name="mediator"></param>
	public UserController(IMediator mediator)
	{
		this.mediator = mediator;
	}

    [HttpGet("/Users/CheckUserExist")]
	public async Task<IActionResult> CheckUserExist()
	{
		var result = await mediator.Send(new CheckUserExistQuery());
		return Ok(new { UserAlreadyExists = result });

	}


	/// <summary>
	/// Creates first user if there is no user in database.
	/// </summary>
	/// <param name="request"></param>
	/// <returns></returns>
	[HttpPost("/Users/CreateFirstUser")]
	[ProducesResponseType(typeof(NoResult), 200)]
	[ProducesResponseType(typeof(Failure), 400)]
	[ProducesResponseType(500)]
	public async Task<IActionResult> CreateFirstUser([FromBody] CreateFirstUserRequest request)
	{
		var result = await mediator.Send(new CreateFirstUserCommand(request.UserName, request.Password));
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