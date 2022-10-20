using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LKenselaar.CloudDatabases.Models;

namespace LKenselaar.CloudDatabases.DAL.EntityTypeConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToContainer("Users")
                .HasNoDiscriminator()
                .HasPartitionKey(u => u.Id);
        }
    }
}
