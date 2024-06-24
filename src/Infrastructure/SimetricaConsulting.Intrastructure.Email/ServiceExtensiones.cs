using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimetricaConsulting.Application.Contracts.Services.V1;
using SimetricaConsulting.Email.Service.V1;
using SimetricaConsulting.Email.Settings;

namespace SimetricaConsulting.Email
{
    public static class ServiceExtensiones
    {
        public static void AddInfrastructureEmail(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            service.AddTransient<IEmailServiceAsync, EmailServiceAsync>();
        }
    }
}