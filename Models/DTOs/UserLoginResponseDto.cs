namespace ISSAPI.Models.DTOs;

public class UserLoginResponseDto(int userId, string username, Role role)
{
    public int UserId { get; set; } = userId;
    public string Username { get; set; } = username;
    public Role Role { get; set; } = role;
}