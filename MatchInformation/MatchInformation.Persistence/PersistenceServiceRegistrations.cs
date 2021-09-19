using MatchInformation.Application.Contracts.Persistence;
using MatchInformation.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MatchInformation.Persistence
{
    public static class PersistenceServiceRegistrations
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MatchInformationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("MatchInformationDbConnectionString"),
                    b => b.MigrationsAssembly(typeof(MatchInformationDbContext).Assembly.FullName)));

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IMatchRepository, MatchRepository>();
            services.AddScoped<IMatchOddsRepository, MatchOddsRepository>();

            return services;
        }
    }
}
