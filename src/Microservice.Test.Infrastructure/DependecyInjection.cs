using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microservice.Test.Application.Common.Interfaces;
using Microservice.Test.Infrastructure.Persistence;
using Microservice.Test.Infrastructure.Services;

namespace Microservice.Test.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddDbContextFactory<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DbConnection"),
                    npgsqlOptions =>
                    {
                        npgsqlOptions.UseNetTopologySuite();
                        npgsqlOptions.MigrationsAssembly(
                            typeof(ApplicationDbContext).Assembly.FullName);
                        npgsqlOptions.EnableRetryOnFailure(
                            15, TimeSpan.FromSeconds(30), null);
                    }).EnableDetailedErrors().EnableSensitiveDataLogging(), ServiceLifetime.Scoped);

            services.AddTransient<IApplicationDbContext>(
                svc => svc.GetRequiredService<ApplicationDbContext>());
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddScoped<IDomainEventService, DomainEventService>();
            
            return services;
        }
    }
}
