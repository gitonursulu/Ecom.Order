using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Application.Interfaces;
using Order.Application.Services;
using Order.Domain.Commands;
using Order.Domain.Events;
using Order.Domain.Interfaces;
using Order.Domain.Queries;
using Order.Domain.Services;
using Order.Infrastructure.Extensions;
using Order.Infrastructure.Context;
using Order.Infrastructure.Repositories;
using System.Reflection;

namespace Order.Infrastructure.IoC
{
    public static class InjectionHelper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("Order.Domain")));
            // Application
            services.AddScoped<IOrderAppService, OrderAppService>();

            // Domain Services
            services.AddScoped<IOrderDomainService, OrderDomainService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<OrderCreatedEvent>, OrderCreatedEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<CreateOrderCommand, bool>, CreateOrderCommandHandler>();

            // Domain - Queries
            services.AddScoped<IRequestHandler<GetOrderByIdQuery, string>, GetOrderByIdQueryHandler>();

            // Infra - Data
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.ConfigureConsul(configuration);
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();

            //servis discovery, health check config
            services.Configure<ConsulConfig>(configuration.GetSection("ConsulConfig"));

            //hostedservices
            services.AddHostedService<ConsulHostedService>();

            //health check
            services.AddHealthChecks();
        }
    }
}
