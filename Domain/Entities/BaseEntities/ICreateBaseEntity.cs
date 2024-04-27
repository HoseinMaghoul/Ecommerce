namespace Domain.Entities.BaseEntities;

public interface ICreateBaseEntity
{
	public DateTime CreatedAt { get; set; }

	public long CreatedByUserID { get; set; }

	public UserEntity? CreatedBy { get; set; }
}
