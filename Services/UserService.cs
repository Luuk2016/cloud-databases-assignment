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

        public async Task UpdateMortgages()
        {
            ICollection<User> users = await _repository.GetAll();

            foreach (User user in users.ToList())
            {
                double calculatedMaximumMortgage = user.AnnualIncome * 5;

                if (user.Mortgage is null)
                {
                    Mortgage mortgage = new Mortgage()
                    {
                        Id = Guid.NewGuid(),
                        MaximumMortgage = calculatedMaximumMortgage,
                        ExpiresAt = DateTime.Now.AddDays(1),
                        MailSend = false
                    };

                    user.Mortgage = mortgage;

                    await _repository.Commit();
                }
            }
        }
    }
}
