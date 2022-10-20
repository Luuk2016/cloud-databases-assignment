using LKenselaar.CloudDatabases.DAL.Context;
using LKenselaar.CloudDatabases.Models;

namespace LKenselaar.CloudDatabases.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(DatabaseContext databaseContext) : base(databaseContext) { }
    }
}
