using Eclipseworks.Application.Interfaces;
using Eclipseworks.Application.Interfaces.Repositories;
using Eclipseworks.Application.Interfaces.Services;
using Eclipseworks.Services.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Eclipseworks.Application.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddServices();
            services.AddAutoMapper();
           // services.AddValidators();
        }

        private static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        private static void AddValidators(this IServiceCollection services)
        {
           // services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private static void AddServices(this IServiceCollection services)
        {
            services
             .AddScoped<IProjetoService, ProjetoService>()
             .AddScoped<IRelatorioService, RelatorioService>()
             .AddScoped<ITarefaHistoricoService, TarefaHistoricoService>()
             .AddScoped<ITarefaService, TarefaService>();
        }
     }
}
