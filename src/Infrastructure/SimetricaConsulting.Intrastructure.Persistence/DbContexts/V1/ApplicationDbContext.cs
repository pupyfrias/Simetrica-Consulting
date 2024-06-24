using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SimetricaConsulting.Application.Extensions;
using SimetricaConsulting.Application.Models;
using SimetricaConsulting.Domain.Contracts;
using SimetricaConsulting.Domain.Entities.V1;
using SimetricaConsulting.Persistence.Configuration.V1;
using Actions = SimetricaConsulting.Application.Enums.Actions;
using Comment = SimetricaConsulting.Domain.Entities.V1.Comment;
using Task = SimetricaConsulting.Domain.Entities.V1.Task;

namespace SimetricaConsulting.Persistence.DbContexts.V1
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string _userName = "default";
        private readonly AuditDbContext _auditDbContext;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            IHttpContextAccessor httpContext,
            AuditDbContext auditDbContext
            ) : base(options)
        {
            _userName = httpContext!.HttpContext!.GetUserName();
            _auditDbContext = auditDbContext;
        }

        public ApplicationDbContext()
        {
        }

        #region DbSets

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Priority> Priorities { get; set; }

        public DbSet<Dashboard> Dashboards { get; set; }

        #endregion DbSets

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new PriorityConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            modelBuilder.ApplyConfiguration(new DashboardConfiguration());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            LogEntityChanges();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            LogEntityChanges();
            return base.SaveChanges();
        }

        private void LogEntityChanges()
        {
            var auditList = new List<Audit>();

            foreach (var entry in ChangeTracker.Entries<IEntityBase>())
            {
                if (entry.State is EntityState.Detached or EntityState.Unchanged)
                    continue;

                var auditEntry = new AuditEntry();
                auditEntry.TableName = entry.Entity.GetType().Name;
                auditEntry.UserName = _userName;

                #region SetAuditInfo

                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _userName;
                        entry.Entity.Created = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _userName;
                        entry.Entity.LastModified = DateTime.Now;
                        break;

                    default:
                        break;
                }

                #endregion SetAuditInfo

                #region AuditProperties

                foreach (var property in entry.Properties)
                {
                    string propertyName = property.Metadata.Name;

                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.Action = Actions.Create;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;

                        case EntityState.Deleted:
                            auditEntry.Action = Actions.Delete;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;

                        case EntityState.Modified:
                            if (property.IsModified &&
                                property.OriginalValue?.ToString() != property.CurrentValue?.ToString())
                            {
                                auditEntry.ChangedColumns.Add(propertyName);
                                auditEntry.Action = Actions.Update;
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }

                            break;
                    }

                    auditList.Add(auditEntry.ToAudit());
                }

                #endregion AuditProperties
            }

            _auditDbContext.AuditLogs.AddRange(auditList);
            _auditDbContext.SaveChanges();
        }
    }
}