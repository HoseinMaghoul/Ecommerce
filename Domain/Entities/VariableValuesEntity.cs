using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class VariableValuesEntity
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public long ID { get; set; }
	[MaxLength(100)]
	public string Value { get; set; } = null!;
	[MaxLength(100)]
	public string? DisplaName { get; set; }
	[ForeignKey("Variable")]
	public long VariableID { get; set; }
	public VariablesEntity? Variable { get; set; }
}
