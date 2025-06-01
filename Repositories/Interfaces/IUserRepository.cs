using ISSAPI.Models;

namespace ISSAPI.Repositories.Interfaces;

public interface IUserRepository
{
    User? FindUserByUsernameAndPassword(string username, string password);
    
    void AddUser(User user);
    
    User? FindUserByUsername(string username);
    
    User? GetUserById(int userId);
}