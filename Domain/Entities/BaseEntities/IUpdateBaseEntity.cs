namespace Domain.Entities.BaseEntities;

public interface IUpdateBaseEntity
{
	public DateTime UpdatedAt { get; set; }

	public long? UpdatedByID { get; set; }

	public UserEntity? UpdatedBy { get; set; }
}
