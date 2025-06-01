using ISSAPI.Data;
using ISSAPI.Models;
using ISSAPI.Repositories.Interfaces;

namespace ISSAPI.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public User? FindUserByUsernameAndPassword(string username, string password)
    {
        return context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
    }

    public void AddUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }

    public User? FindUserByUsername(string username)
    {
        return context.Users.FirstOrDefault(u => u.Username == username);
    }
    
    public User? GetUserById(int userId)
    {
        return context.Users.FirstOrDefault(u => u.Id == userId);
    }
}