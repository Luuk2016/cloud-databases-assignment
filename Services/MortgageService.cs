using LKenselaar.CloudDatabases.Models;
using LKenselaar.CloudDatabases.Services.Interfaces;

namespace LKenselaar.CloudDatabases.Services
{
    public class MortgageService : IMortgageService
    {
        public Task<Mortgage> CreateMortage(Mortgage mortgage)
        {
            throw new NotImplementedException();
        }

        public Task<Mortgage> GetMortgage(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
