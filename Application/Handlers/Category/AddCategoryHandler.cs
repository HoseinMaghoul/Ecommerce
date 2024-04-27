using Application.Failures;
using Application.Commands.Categories;
using Application.Results;
using Domain.IServices;
using MediatR;
using OneOf;
using Domain.Entities;
using Application.Results.Category;

namespace Application.Handlers.Category;





public class AddCategoryHandler : IRequestHandler<AddCategoryCommand, OneOf<AddCategoryResult, CategoryFailure>>
{

        private readonly ICategoryService categoryService;

        public AddCategoryHandler(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
    public async Task<OneOf<AddCategoryResult, CategoryFailure>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
    
        if (request.Name is null)
        {
            return new CategoryNameCanNotBeNull();
        }

        await categoryService.AddCategoryAsync(request.Name, request.Slug, request.ParentId);

        return new AddCategoryResult(request.Name);
    }
    }







// public class AddCategoryHandler : IRequestHandler<AddCategoryCommand, OneOf<AddCategoryResult, CategoryFailure>>
// {
//     private readonly ICategoryService categoryService;

//     public AddCategoryHandler(ICategoryService categoryService)
//     {
//         this.categoryService = categoryService;
//     }
//     public async Task<OneOf<AddCategoryResult, CategoryFailure>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
//     {
//         try 
//         {
//             var category = new CategoryEntity
//             {
//                 Name = request.Name,
//                 Slug = request.Slug,
//                 ParentId = request.ParentId
//             };
//             await categoryService.AddCategoryAsync(category);
//             return new  AddCategoryResult(request.Name);
//         }
//         catch
//         {
//             return new CanNotAddCategory();

//         }
//     }
// }
