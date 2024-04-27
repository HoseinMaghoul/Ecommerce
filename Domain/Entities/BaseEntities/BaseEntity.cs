using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.BaseEntities;

public class BaseEntity : ICreateBaseEntity, IUpdateBaseEntity
{
	public long ID { get; set; }
	public DateTime CreatedAt { get; set; }
	[ForeignKey("CreatedBy")]
	public long CreatedByUserID { get; set; }
	public UserEntity? CreatedBy { get; set; }
	public DateTime UpdatedAt { get; set; }
	[ForeignKey("UpdatedBy")]
	public long? UpdatedByID { get; set; }
	public UserEntity? UpdatedBy { get; set; }
}
