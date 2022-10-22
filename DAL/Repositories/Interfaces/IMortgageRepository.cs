using LKenselaar.CloudDatabases.Models;

namespace LKenselaar.CloudDatabases.DAL.Repositories.Interfaces
{
    public interface IMortgageRepository : IBaseRepository<Mortgage>
    {
        public Task<Mortgage> GetMortgageByUserId(Guid userId);
    }
}
