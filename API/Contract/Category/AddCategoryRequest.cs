
using Domain.Entities;

namespace API.Contract.Category;
/// <summary>
/// Add Category
/// </summary>
/// <param name="Name"></param>
/// <param name="Slug"></param>
/// <param name="ParentId"></param>

public record AddCategoryRequest(
    string Name,
    string Slug,
    int? ParentId
);