namespace Services.Models;

using Services.DAL.Models;

public class UserDto : BaseDto
{
    public string PasswordHash { get; set; }

    public string Name { get; set; }
    public string Phone { get; set; }
    public Role Role { get; set; }
}
