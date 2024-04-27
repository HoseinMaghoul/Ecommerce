using Application.Commands.Contact;
using API.Contract.Contact;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using API.Controllers;
using Application.Results;
using Application.Failures;
using Domain.Entities;


namespace API.Controllers;
/// <summary>
/// ContactController
/// </summary>
/// 

public class ContactController : BaseController
{
    private readonly IMediator mediator;

    public ContactController(IMediator mediator) => this.mediator = mediator;

    /// <summary>
    /// API For Contact To Us
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>

    [HttpPost("/Contact")]
    [ProducesResponseType(typeof(NoResult), 200)]
    [ProducesResponseType(typeof(Failure), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> ContactUs([FromBody] ContactRequest request)
    {
        var result = await mediator.Send(new ContactCommand(request.Name, request.Title, request.PhoneNumber, request.Email, request.Text));
        if (result.IsT1)
        {
            return BadRequest(result.AsT1);
        }
        else
        {
            return Ok(result.AsT0);
        }
    }


// [HttpPost("/Contact")]
// [ProducesResponseType(typeof(NoResult), 200)]
// [ProducesResponseType(typeof(ContactFailure), 400)]
// [ProducesResponseType(500)]
// public async Task<IActionResult> ContactUs([FromBody] ContactRequest request)
// {
//     var command = new ContactCommand(new ContactEntity
//     {
//         Name = request.Name,
//         Title = request.Title,
//         PhoneNumber = request.PhoneNumber,
//         Email = request.Email,
//         Text = request.Text
//     });

//     var result = await mediator.Send(command);

//     if (result.IsT1)
//     {
//         return BadRequest(result.AsT1);
//     }
//     else
//     {
//         return Ok(result.AsT0);
//     }
}



