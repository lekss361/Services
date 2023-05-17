namespace Services.BAL.Services;

public interface IAuthService
{
    string Login(int id, string password);
}