using LKenselaar.CloudDatabases.CustomExceptions;
using LKenselaar.CloudDatabases.DAL.Repositories.Interfaces;
using LKenselaar.CloudDatabases.Models;
using LKenselaar.CloudDatabases.Services.Interfaces;

namespace LKenselaar.CloudDatabases.Services
{
    public class MortgageService : Service<Mortgage>, IMortgageService
    {
        private readonly IMortgageRepository _mortgageRepository;

        public MortgageService(IBaseRepository<Mortgage> repository, IMortgageRepository mortgageRepository) : base(repository)
        {
            _mortgageRepository = mortgageRepository;
        }

        public async Task<Mortgage> GetMortgageByUserId(Guid userId)
        {
            Mortgage mortgage = await _mortgageRepository.GetMortgageByUserId(userId);

            if (mortgage.ExpiresAt < DateTime.UtcNow)
            {
                throw new CustomException(ErrorCodes.MortgageExpired.Key, string.Format(ErrorCodes.MortgageExpired.Value));
            }

            return mortgage;
        }
    }
}
