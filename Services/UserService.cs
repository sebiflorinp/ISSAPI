using ISSAPI.Models;
using ISSAPI.Models.DTOs;
using ISSAPI.Repositories.Interfaces;

namespace ISSAPI.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public User? LoginUser(string username, string password)
    {
        return _userRepository.FindUserByUsernameAndPassword(username, password);
    }
    
    public void RegisterUser(UserDto newUser)
    {
        // Check if the username isn't already taken
        if (_userRepository.FindUserByUsername(newUser.Username) != null)
        {
            throw new InvalidOperationException("There is already a user with the given username.");
        }
        
        var userToAdd = new User(newUser.Username, newUser.Password, Role.User);
        _userRepository.AddUser(userToAdd);
    }

    public User? GetUserById(int userId)
    {
        return _userRepository.GetUserById(userId);
    }
}