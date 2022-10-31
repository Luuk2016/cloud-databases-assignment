using LKenselaar.CloudDatabases.DAL.Repositories.Interfaces;
using LKenselaar.CloudDatabases.Models;
using LKenselaar.CloudDatabases.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace LKenselaar.CloudDatabases.Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly ILogger<UserService> _logger;

        public UserService(ILogger<UserService> logger, IBaseRepository<User> repository) : base(repository) 
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override async Task<User> Create(User user)
        {
            return await _repository.Create(user);
        }

        public async Task CalculateMortgages()
        {
            foreach (User user in await _repository.GetAll())
            {
                if (user.Mortgage is null)
                {
                    Mortgage mortgage = new Mortgage()
                    {
                        Id = Guid.NewGuid(),
                        MaximumMortgage = user.AnnualIncome * 5,
                        ExpiresAt = DateTime.Now.AddDays(1),
                        MailSend = false
                    };

                    user.Mortgage = mortgage;

                    await _repository.Commit();
                }
                else
                {
                    _logger.LogInformation($"UserId: {user.Id} - mortgage has already been set");
                }
            }
        }
    }
}
