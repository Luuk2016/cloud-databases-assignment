using LKenselaar.CloudDatabases.DAL.Repositories.Interfaces;
using LKenselaar.CloudDatabases.Models;
using LKenselaar.CloudDatabases.Services.Interfaces;

namespace LKenselaar.CloudDatabases.Services
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(IBaseRepository<User> repository) : base(repository) { }

        public override async Task<User> Create(User user)
        {
            return await _repository.Create(user);
        }
    }
}
