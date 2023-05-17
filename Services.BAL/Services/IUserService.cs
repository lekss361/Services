namespace Services.BAL.Services;

public interface IUserService
{
    int Add(global::Services.Models.UserDto entity, string password);
}