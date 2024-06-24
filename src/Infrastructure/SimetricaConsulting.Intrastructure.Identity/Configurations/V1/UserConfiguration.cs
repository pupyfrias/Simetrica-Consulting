using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimetricaConsulting.Identity.Entities;
using SimetricaConsulting.Identity.Seeds;

namespace SimetricaConsulting.Identity.Configurations.V1
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasQueryFilter(x => x.Active.HasValue && x.Active.Value);

            builder.Property(p => p.FirstName)
                .IsRequired();

            builder.Property(p => p.LastName)
                .IsRequired();

            builder.Property(p => p.Created)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(p => p.Active)
                .HasDefaultValue(true);

            builder.HasData(UserSeed.Data);
        }
    }
}