using Domain.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Entities;

public class ProductEntity
{
     public long Id {get; set;}

     [Required]
    public string Name { get; set; }

    public ICollection<CategoryProductEntity> CategoryProducts { get; set; } = null!;

    public string ImagePath {get; set;} = null!;
    
    public string Description {get; set;} = null!;

    public decimal Price {get; set;}

    public bool Available {get; set;} = true;


   

    public class CategoryProductEntity
{
    [Key]
    public long CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;

    [Key]
    public long ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
}

}




 // public class CategoryProductEntity
    // {

    //     [ForeignKey(nameof(product))]
	//     public long productId { get; set; }
	//     public ProductEntity? product { get; set; }


    //     [ForeignKey(nameof(category))]
	//     public long categoryId { get; set; }
	//     public CategoryEntity? category { get; set; }

    // }