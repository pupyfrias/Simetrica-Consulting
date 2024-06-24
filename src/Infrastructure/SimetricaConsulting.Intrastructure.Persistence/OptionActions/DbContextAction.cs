using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SimetricaConsulting.Persistence.DbContexts;
using SimetricaConsulting.Persistence.DbContexts.V1;

namespace SimetricaConsulting.Persistence.OptionActions
{
    public static class DbContextAction
    {
        public static readonly Func<IConfiguration, Action<DbContextOptionsBuilder>> DbOptions = configuration =>
        {
            Action<DbContextOptionsBuilder> Options = (options) =>
            {
                options.UseOracle(configuration.GetConnectionString("SimetricaConsultingConnection"),
                            optionBuilder => optionBuilder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            };

            return Options;
        };

        public static readonly Func<IConfiguration, Action<DbContextOptionsBuilder>> AuditDbOptions = configuration =>
        {
            Action<DbContextOptionsBuilder> Options = (options) =>
            {
                options.UseOracle(configuration.GetConnectionString("SimetricaConsultingAuditConnection"),
                            optionBuilder => optionBuilder.MigrationsAssembly(typeof(AuditDbContext).Assembly.FullName));
            };

            return Options;
        };




    }
}