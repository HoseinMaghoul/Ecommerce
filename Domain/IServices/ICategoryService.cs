using Domain.DTOs;
using Domain.Entities;
using Domain.Enums;


namespace Domain.IServices;


public interface ICategoryService
{
    
    Task AddCategoryAsync(string Name, string Slug, int? ParentId);
}