using LKenselaar.CloudDatabases.DAL.Context;
using LKenselaar.CloudDatabases.Models;

namespace LKenselaar.CloudDatabases.DAL.Repositories
{
    public class MortgageRepository : BaseRepository<Mortgage>
    {
        public MortgageRepository(DatabaseContext databaseContext) : base(databaseContext) { }
    }
}
