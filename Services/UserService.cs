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
            var users = await _repository.GetAll();

            foreach (var user in users.ToList())
            {
                double calculatedMaximumMortgage = user.AnnualIncome * 5;

                if (user.Mortgage == null)
                {
                    Mortgage mortgage = new Mortgage()
                    {
                        Id = Guid.NewGuid(),
                        MaximumMortgage = calculatedMaximumMortgage,
                        UserId = user.Id
                    };

                    user.Mortgage = mortgage;
                }
                else
                {
                    user.Mortgage.MaximumMortgage = calculatedMaximumMortgage;
                }

                await _repository.Commit();
            }
        }
    }
}
