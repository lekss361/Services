namespace Services.Models;

using Services.DAL.Models;

public class RoleDto : BaseDto
{
    public string Name { get; set; }
}

public enum Role
{
    Admin = 1,
    Manager,
    User
}
