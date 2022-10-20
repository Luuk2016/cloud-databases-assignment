using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LKenselaar.CloudDatabases.Models;

namespace LKenselaar.CloudDatabases.DAL.EntityTypeConfigurations
{
    public class MortgageEntityTypeConfiguration : IEntityTypeConfiguration<Mortgage>
    {
        public void Configure(EntityTypeBuilder<Mortgage> builder)
        {
            builder
                .ToContainer("Mortgages")
                .HasPartitionKey(u => u.Id);
        }
    }
}
