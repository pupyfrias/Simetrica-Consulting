using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimetricaConsulting.Identity.Seeds;

namespace SimetricaConsulting.Identity.Configurations.V1
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.ToTable("Roles");

            builder.HasData(RoleSeed.Data);
        }
    }
}