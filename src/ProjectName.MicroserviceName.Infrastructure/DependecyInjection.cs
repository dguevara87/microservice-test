using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.MicroserviceName.Application.Common.Interfaces;
using ProjectName.MicroserviceName.Infrastructure.Persistence;

namespace ProjectName.MicroserviceName.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
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
            return services;
        }
    }
}
