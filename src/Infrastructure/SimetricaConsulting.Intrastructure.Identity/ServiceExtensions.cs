using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using SimetricaConsulting.Application.Constants;
using SimetricaConsulting.Application.Extensions;
using SimetricaConsulting.Application.Models.Wrappers;
using SimetricaConsulting.Identity.Contracts.Repositories.V1;
using SimetricaConsulting.Identity.Contracts.Services.V1;
using SimetricaConsulting.Identity.DbContext.V1;
using SimetricaConsulting.Identity.Entities;
using SimetricaConsulting.Identity.Repositories.V1;
using SimetricaConsulting.Identity.Services.V1;
using SimetricaConsulting.Identity.Settings;
using SimetricaConsulting.Identity.TokenProviderConfigurations;
using SimetricaConsulting.Identity.TokenProviderConfigurations.EmailConfirmation;
using SimetricaConsulting.Identity.TokenProviderConfigurations.PasswordReset;
using System.Text;

namespace SimetricaConsulting.Identity
{
    public static class ServiceExtensions
    {
        public static void AddIdentityInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region DbContext
            services.AddDbContext<IdentityContext>(option =>
            {
                option.UseOracle(configuration.GetConnectionString("SimetricaConsultingIdentityConnection"),
                    optionBuilder => optionBuilder.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName));

                option.EnableSensitiveDataLogging();
            });

            #endregion DbContext

            #region Configure

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            #endregion Configure

            #region Identity

            var jwtSettings = new JwtSettings();
            configuration.Bind("JwtSettings", jwtSettings);

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Password.RequiredLength = 8;
                options.SignIn.RequireConfirmedEmail = true;
                options.User.RequireUniqueEmail = true;
                options.Tokens.EmailConfirmationTokenProvider = TokenProviders.EmailConfirmation;
                options.Tokens.PasswordResetTokenProvider = TokenProviders.PasswordReset;
                options.Tokens.ChangeEmailTokenProvider = TokenProviders.ChangeEmail;
            }).AddEntityFrameworkStores<IdentityContext>()
              .AddDefaultTokenProviders()
              .AddTokenProvider<EmailConfirmationTokenProvider<User>>(TokenProviders.EmailConfirmation)
              .AddTokenProvider<PasswordResetTokenProvider<User>>(TokenProviders.PasswordReset);

            services.Configure<EmailConfirmationTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(jwtSettings.EmailConfirmationTokenDurationInHours);
            });

            services.Configure<PasswordResetTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromMinutes(jwtSettings.PasswordResetTokenDurationInMinutes);
            });



            #endregion Identity

            #region Dependency injection

            // Repositories
            services.AddScoped<IUserRepositoryAsync, UserRepositoryAsync>();
            services.AddScoped<IRoleRepositoryAsync, RoleRepositoryAsync>();
           

            //Services
            services.AddScoped<IUserServiceAsync, UserServiceAsync>();
            services.AddScoped<IAuthServiceAsync, AuthServiceAsync>();
            services.AddScoped<IRoleServiceAsync, RoleServiceAsync>();


            #endregion Dependency injection

            #region Authentication

            var key = Encoding.UTF8.GetBytes(jwtSettings.Key);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidAudience = jwtSettings.Audience,
                    ValidIssuer = jwtSettings.Issuer,
                };
                options.Events = new JwtBearerEvents()
                {
                    OnChallenge = async (context) =>
                    {
                        var statusCode = StatusCodes.Status401Unauthorized;
                        context.Response.StatusCode = statusCode;
                        context.HandleResponse();

                        var response = new ApiResponse(statusCode, "You are not authenticated");

                        await context.Response.WriteAsJsonAsync(response);
                        Log.Warning(response.Message);
                    },
                    OnForbidden = async (context) =>
                    {
                        var statusCode = StatusCodes.Status403Forbidden;
                        context.Response.StatusCode = statusCode;
                        context.Response.ContentType = "application/json";

                        var response = new ApiResponse(statusCode, "You are not authorized to access this resource");

                        await context.Response.WriteAsJsonAsync(response);
                        string pathRequest = context.HttpContext.Request.Path;
                        string userName = context.HttpContext.GetUserName();

                        Log.Warning($"User {userName} is not authorized to access {pathRequest}");
                    }
                };
            });

            #endregion Authentication

        }
    }
}