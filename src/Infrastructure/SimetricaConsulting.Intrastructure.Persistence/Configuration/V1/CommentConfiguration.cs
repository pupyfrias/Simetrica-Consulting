using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimetricaConsulting.Application.Configuration;
using SimetricaConsulting.Domain.Entities.V1;

namespace SimetricaConsulting.Persistence.Configuration.V1
{
    public class CommentConfiguration : EntityBaseConfiguration<Comment, int>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {

            base.Configure(builder);


            builder.ToTable("Comment");

            builder.Property(c => c.Content)
           .IsRequired()
           .HasMaxLength(1000);

            builder.Property(c => c.CreatedDate)
                .IsRequired();

            builder.HasOne(c => c.Task)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TaskId);
        }
    }
}