﻿using Order.Infrastructure.IoC;

namespace Order.OrderAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            InjectionHelper.RegisterServices(services, configuration);
        }
    }
}
