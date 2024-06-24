using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimetricaConsulting.Application.Configuration;
using SimetricaConsulting.Domain.Entities.V1;
using SimetricaConsulting.Persistence.Seeds;

namespace SimetricaConsulting.Persistence.Configuration.V1
{
    public class PriorityConfiguration : EntityBaseConfiguration<Priority, int>
    {
        public override void Configure(EntityTypeBuilder<Priority> builder)
        {

            base.Configure(builder);

            builder.ToTable("Priority");

            builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasData(PrioritySeed.Data);
        }
    }
}