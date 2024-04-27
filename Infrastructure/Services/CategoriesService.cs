using System.Diagnostics.Contracts;
using System.Text;
using Domain.IServices;
using Infrastructure.DBContext;
using Domain.Entities;
using static Domain.Entities.ProductEntity;
using System.Data.Entity;

namespace Infrastructure.Services;


public class CategoriesService : ICategoryService
{
    private readonly ProjectDbContext context;

    

    public CategoriesService(ProjectDbContext context)
    {
        this.context = context;
    }

    public async Task  AddCategoryAsync(string Name, string Slug, int? ParentId)
    {
        var category = new CategoryEntity
        {
            Name = Name,
            Slug = Slug,
            ParentId = ParentId
        };

        context.Categories.Add(category);
        context.SaveChanges();

         
    }

        
    




    // public async Task<CategoryEntity> AddCategoryAsync(CategoryEntity category)
    //     {

    //         if (category == null)
    //         {
    //             throw new ArgumentNullException(nameof(category));
    //         }

    //         if (string.IsNullOrWhiteSpace(category.Name))
    //         {
    //             throw new ArgumentException("Category name cannot be null or empty.", nameof(category.Name));
    //         }

    //         if (category.ParentId.HasValue && !await context.Categories.AnyAsync(c => c.ID == category.ParentId.Value))
    //         {
    //             throw new ArgumentException("Parent category does not exist.", nameof(category.ParentId));
    //         }


    //         // var categoryProductEntity = new CategoryProductEntity 
    //         // {
    //         //     CategoryId = category.ID.Value,
    //         //     ProductId = category.ID.Value
    //         // };

    //         // // Add the new category to the database using a repository or DbContext
    //         // category.CategoryProducts = new List<CategoryProductEntity> { categoryProductEntity };
    //         await context.Categories.AddAsync(category);

    //         return category;
    //     }



}
    

  


