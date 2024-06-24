using Microsoft.EntityFrameworkCore;
using SimetricaConsulting.Domain.Entities.V1;

namespace SimetricaConsulting.Persistence.DbContexts
{
    public class AuditDbContext : DbContext
    {
        public AuditDbContext(DbContextOptions<AuditDbContext> options) : base(options)
        {
        }

        public DbSet<Audit> AuditLogs { get; set; }
    }
}