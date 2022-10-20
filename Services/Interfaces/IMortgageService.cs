using LKenselaar.CloudDatabases.Models;

namespace LKenselaar.CloudDatabases.Services.Interfaces
{
    public interface IMortgageService
    {
        Task<Mortgage> CreateMortage(Mortgage mortgage);
        Task<Mortgage> GetMortgage(Guid id);
    }
}
