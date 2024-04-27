using Application.Commands.Categories;
using Application.Results.Category;
using API.Contract.Category;
using Application.Failures;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using API.Controllers;


namespace API.Controllers;
/// <summary>
/// CategoryController
/// </summary>
public  class CategoryController : BaseController
{
    private readonly IMediator mediator;
     /// <summary>
    /// Initializes a new instance of the <see cref="CategoryController"/> class.
    /// </summary>
    /// <param name="mediator"></param>



    public CategoryController(IMediator mediator) => this.mediator = mediator;

    /// <summary>
    /// API for Add Category
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// 
    [HttpPost("/Add/Category")]
    [ProducesResponseType(typeof(AddCategoryResult), 200)]
    [ProducesResponseType(typeof(CategoryFailure), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> AddCategory([FromBody] AddCategoryRequest request)
    {
        var result  = await mediator.Send(new AddCategoryCommand(request.Name, request.Slug, request.ParentId));
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