using Domain.Enums;

namespace Domain.DTOs;
public class UserNameWithPasswordDTO {
    public long Id { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }

    public string? Salt { get; set; }
    
    public List<Role> Roles { get; set; } = new List<Role>();
}