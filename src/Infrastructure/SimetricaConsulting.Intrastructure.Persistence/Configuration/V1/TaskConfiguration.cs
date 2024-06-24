using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimetricaConsulting.Application.Configuration;
using Task = SimetricaConsulting.Domain.Entities.V1.Task;

namespace SimetricaConsulting.Persistence.Configuration.V1
{
    public class TaskConfiguration : EntityBaseConfiguration<Task, int>
    {
        public override void Configure(EntityTypeBuilder<Task> builder)
        {

            base.Configure(builder);

            builder.ToTable("Task");

            builder.Property(t => t.Title)
             .IsRequired()
             .HasMaxLength(200);

            builder.Property(t => t.Description)
                .HasMaxLength(1000);

            builder.Property(t => t.DueDate)
                .IsRequired();

            builder.Property(t => t.CreatedDate)
                .IsRequired();

            builder.Property(t => t.UpdatedDate)
                .IsRequired();

            builder.HasOne(t => t.Status)
                .WithMany()
                .HasForeignKey(t => t.StatusId)
                .IsRequired();

            builder.HasOne(t => t.Priority)
                .WithMany()
                .HasForeignKey(t => t.PriorityId)
                .IsRequired();

            builder.HasOne(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.ProjectId);

            builder.HasMany(t => t.Comments)
                .WithOne(c => c.Task)
                .HasForeignKey(c => c.TaskId);
        }
    }
}