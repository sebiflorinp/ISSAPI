namespace ISSAPI.Models.DTOs;

public class UserDto(string username, string password)
{
    public string Username { get; set; } = username;
    public string Password { get; set; } = password;
}