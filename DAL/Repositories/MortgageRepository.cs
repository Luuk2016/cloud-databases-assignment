using LKenselaar.CloudDatabases.DAL.Context;
using LKenselaar.CloudDatabases.DAL.Repositories.Interfaces;
using LKenselaar.CloudDatabases.Models;
using Microsoft.EntityFrameworkCore;

namespace LKenselaar.CloudDatabases.DAL.Repositories
{
    public class MortgageRepository : BaseRepository<Mortgage>, IMortgageRepository
    {
        public MortgageRepository(DatabaseContext databaseContext) : base(databaseContext) { }

        public async Task<Mortgage> GetMortgageByUserId(Guid userId)
        {
            User user = await _databaseContext.Users
                .SingleOrDefaultAsync(u => u.Id == userId);

            return user.Mortgage;
        }
    }
}
