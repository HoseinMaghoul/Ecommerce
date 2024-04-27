using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class VariablesEntity
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public long ID { get; set; }
	[MaxLength(100)]
	public string VaribaleName { get; set; } = null!;
}
