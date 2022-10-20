using LKenselaar.CloudDatabases.Models;

namespace LKenselaar.CloudDatabases.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);
        Task<User> GetUser(Guid id);
    }
}
