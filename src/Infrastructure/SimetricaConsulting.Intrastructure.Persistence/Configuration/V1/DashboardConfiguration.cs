using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimetricaConsulting.Application.Configuration;
using SimetricaConsulting.Domain.Entities.V1;
using SimetricaConsulting.Persistence.Seeds;

namespace SimetricaConsulting.Persistence.Configuration.V1
{
    public class DashboardConfiguration : EntityBaseConfiguration<Dashboard, int>
    {
        public override void Configure(EntityTypeBuilder<Dashboard> builder)
        {

            base.Configure(builder);

            builder.ToTable("Dashboard");

            builder.Property(d => d.TotalTasks)
                       .IsRequired();

            builder.Property(d => d.CompletedTasks)
                .IsRequired();

            builder.Property(d => d.PendingTasks)
                .IsRequired();

            builder.Property(d => d.OverdueTasks)
                .IsRequired();

            builder.Property(d => d.Projects)
                .IsRequired();

            builder.Property(d => d.UserId)
                      .IsRequired();
        }
    }
}