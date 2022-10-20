using LKenselaar.CloudDatabases.DAL.Repositories.Interfaces;
using LKenselaar.CloudDatabases.Models;
using LKenselaar.CloudDatabases.Services.Interfaces;

namespace LKenselaar.CloudDatabases.Services
{
    public class MortgageService : Service<Mortgage>, IMortgageService
    {
        public MortgageService(IBaseRepository<Mortgage> repository) : base(repository) { }
    }
}
