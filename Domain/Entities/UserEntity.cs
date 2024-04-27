using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Entities;

public class UserEntity
{
    public long ID { get; set; }
	[MaxLength(100)]

    public string FirstName { get; set; } = null!;
	[MaxLength(100)]

    public string LastName { get; set; } = null!;
	[MaxLength(100)]

    public string? Salt { get; set; }


    public string? UserName { get;set; }

    public string? Password { get; set; }

    public DateTime BirthDate { get; set; }


    public string? PhoneNumber { get; set; }
	[MaxLength(100)]

    public string? Gender { get; set; }
	[MaxLength(100)]

    

    public bool IsActive { get; set; }
	[MaxLength(100)]

    public long? ProfileImageID { get; set; }

	public FilesEntity? ProfileImage { get; set; }
	[ForeignKey("SmallProfileImage")]

	public long? SmallProfileImageID { get; set; }

	public FilesEntity? SmallProfileImage { get; set; }

}