using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimetricaConsulting.Application.Configuration;
using SimetricaConsulting.Domain.Entities.V1;

namespace SimetricaConsulting.Persistence.Configuration.V1
{
    public class ProjectConfiguration : EntityBaseConfiguration<Project, int>
    {
        public override void Configure(EntityTypeBuilder<Project> builder)
        {

            base.Configure(builder);

            builder.ToTable("Project");

            builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(200);

            builder.Property(p => p.Description)
                .HasMaxLength(1000);

            builder.Property(p => p.StartDate)
                .IsRequired();

            builder.Property(p => p.EndDate)
                .IsRequired();

            builder.HasMany(p => p.Tasks)
                .WithOne(t => t.Project)
                .HasForeignKey(t => t.ProjectId);
        }
    }
}