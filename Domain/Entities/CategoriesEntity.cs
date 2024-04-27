// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
// using System.Reflection;


// namespace Domain.Entities;

// public class CategoriesEntity
// {
//     [Key]
//     public int Id { get; set; }

//     [Required]
//     public string Name { get; set; }

//     [ForeignKey("ParentCategory")]
//     public int? ParentId { get; set; }
//     public CategoriesEntity ParentCategory { get; set; }

//     public int LeftValue { get; set; }
//     public int RightValue { get; set; }
//     public int Depth { get; set; }
// }