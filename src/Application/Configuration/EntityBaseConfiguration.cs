using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimetricaConsulting.Domain.Common;


namespace SimetricaConsulting.Application.Configuration
{
    public abstract class EntityBaseConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase<TKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasQueryFilter(x => x.Active.HasValue && x.Active.Value);

            builder.Property(x => x.CreatedBy)
                  .HasDefaultValue("default");

            builder.Property(x => x.Created)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(x => x.LastModifiedBy);

            builder.Property(x => x.LastModified);

            builder.Property(x => x.Active)
                   .HasDefaultValue(true);

        }
    }
}