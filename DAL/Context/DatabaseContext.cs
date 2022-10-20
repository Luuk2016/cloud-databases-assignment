using LKenselaar.CloudDatabases.DAL.EntityTypeConfigurations;
using LKenselaar.CloudDatabases.Models;
using Microsoft.EntityFrameworkCore;

namespace LKenselaar.CloudDatabases.DAL.Context
{
    public class DatabaseContext : DbContext
    {
        private readonly FunctionConfiguration _config;

        public DbSet<User> Users { get; set; }
        public DbSet<Mortgage> Mortgages { get; set; }

        public DatabaseContext(FunctionConfiguration config)
        {
            _config = config;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
/*            modelBuilder.ApplyConfiguration(new MortgageEntityTypeConfiguration());
*/        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(
                accountEndpoint: _config.CosmosAccountEndpoint,
                accountKey: _config.CosmosAccountKey,
                databaseName: _config.CosmosDatabaseName
            );
        }
    }
}
