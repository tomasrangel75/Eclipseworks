﻿using Eclipseworks.Application.Interfaces;
using Eclipseworks.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Eclipseworks.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services
                .AddTransient<IDateTimeService, DateTimeService>();
        }
    }
}
