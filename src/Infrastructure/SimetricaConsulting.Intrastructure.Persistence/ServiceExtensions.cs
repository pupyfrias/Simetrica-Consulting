using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimetricaConsulting.Application.Contracts.Repositories.V1;
using SimetricaConsulting.Persistence.DbContexts;
using SimetricaConsulting.Persistence.DbContexts.V1;
using SimetricaConsulting.Persistence.OptionActions;
using SimetricaConsulting.Persistence.Repositories;
using SimetricaConsulting.Persistence.Repositories.V1;

namespace SimetricaConsulting.Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region DbContext

            services.AddDbContext<ApplicationDbContext>(DbContextAction.DbOptions(configuration));
            services.AddDbContext<AuditDbContext>(DbContextAction.AuditDbOptions(configuration));
            #endregion DbContext

            #region Dependency Injection

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IPriorityRepository, PriorityRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IDashboardRepository, DashboardRepository>();


            #endregion Dependency Injection
        }
    }
}