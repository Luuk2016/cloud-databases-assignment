using LKenselaar.CloudDatabases.Models;
using LKenselaar.CloudDatabases.Services.Interfaces;

namespace LKenselaar.CloudDatabases.Services
{
    public class UserService : IUserService
    {
        public Task<User> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
