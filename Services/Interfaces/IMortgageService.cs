using LKenselaar.CloudDatabases.Models;

namespace LKenselaar.CloudDatabases.Services.Interfaces
{
    public interface IMortgageService : IBaseService<Mortgage>
    {
        public Task<Mortgage> GetMortgageByUserId(Guid userId);
    }
}
