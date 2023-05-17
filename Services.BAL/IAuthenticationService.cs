namespace DevEdu.Business.Services;

using global::Services.Models;

public interface IAuthenticationService
{
    Task<string> SignInAsync(UserDto dto);
    Task<byte[]> GetSaltAsync();
    Task<string> HashPasswordAsync(string pass, byte[] salt = null);
    Task<bool> VerifyAsync(string hashedPassword, string userPassword);
}