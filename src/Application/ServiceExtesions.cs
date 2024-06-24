using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimetricaConsulting.Application.Contracts.Services.V1;
using SimetricaConsulting.Application.Services;
using SimetricaConsulting.Application.Services.V1;
using SimetricaConsulting.Application.SetupOptions;

namespace SimetricaConsulting.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApiVersioning(ApiVersioning.Options);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers().ConfigureApiBehaviorOptions(ApiBehavior.Options);
            services.AddCors(Cors.Options);
            services.AddEndpointsApiExplorer();
            services.AddHttpContextAccessor();
            services.AddMemoryCache();
            services.AddMvc(options => options.SuppressAsyncSuffixInActionNames = false);
            services.AddSwaggerGen(SwaggerGen.Options);
            services.AddVersionedApiExplorer(ApiExplorer.Options);

            #region Dependency Injection

            services.AddScoped(typeof(IAsyncService<>), typeof(ServiceBase<>));
            services.AddScoped<StatusService, StatusService>();
            services.AddScoped<IPriorityService, PriorityService>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IDashboardService, DashboardService>();

            #endregion Dependency Injection

        }
    }
}