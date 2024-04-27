using Domain.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;
using static Domain.Entities.ProductEntity;


namespace Domain.Entities;



public class CategoryEntity
{
    public long Id {get; set;}
    public int? ParentId { get; set; }
    public CategoryEntity? ParentCategory { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public ICollection<CategoryProductEntity> CategoryProducts { get; set; } = null!;
}




