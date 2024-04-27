using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class FilesEntity
{
	public long ID { get; set; }
	[MaxLength(100)]
	public string Path { get; set; } = null!;
	[MaxLength(100)]
	public string Extension { get; set; } = null!;
	public int Lenght { get; set; }
	[MaxLength(100)]
	public string RelatedColumnName { get; set; } = null!;
	[MaxLength(100)]
	public string RelatedTableName { get; set; } = null!;
	[MaxLength(100)]
	public string RelatedRecordID { get; set; } = null!;
}
