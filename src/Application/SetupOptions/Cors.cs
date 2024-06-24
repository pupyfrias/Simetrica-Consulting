using Microsoft.AspNetCore.Cors.Infrastructure;

namespace SimetricaConsulting.Application.SetupOptions
{
    public static class Cors
    {
        public static readonly Action<CorsOptions> Options = options =>
        {
            options.AddPolicy("AllowAll", policy =>
               policy.AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader());
        };
    }
}