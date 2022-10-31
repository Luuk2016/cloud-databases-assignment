using LKenselaar.CloudDatabases.Models;

namespace LKenselaar.CloudDatabases.Services.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        public Task CalculateMortgages();
    }
}
