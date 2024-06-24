using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimetricaConsulting.Application.Configuration;
using SimetricaConsulting.Domain.Entities.V1;
using SimetricaConsulting.Persistence.Seeds;

namespace SimetricaConsulting.Persistence.Configuration.V1
{
    public class StatusConfiguration : EntityBaseConfiguration<Status, int>
    {
        public override void Configure(EntityTypeBuilder<Status> builder)
        {

            base.Configure(builder);

            builder.ToTable("Status");

            builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasData(StatusSeed.Data);
        }
    }
}