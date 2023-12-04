using Eclipseworks.Application.Interfaces.Repositories;
using Eclipseworks.Persistence.Context;
using Eclipseworks.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eclipseworks.Persistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddRepositories();
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"), opt =>
                {
                    opt.CommandTimeout(180);
                    opt.EnableRetryOnFailure(5);
                });
            });

        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddScoped<IProjetoRepository, ProjetoRepository>()
                .AddScoped<ITarefaHistoricoRepository, TarefaHistoricoRepository>()
                .AddScoped<ITarefaRepository, TarefaRepository>();
        }
    }
}
