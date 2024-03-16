using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Order.Application.Interfaces;
using Order.Application.Services;
using Order.Domain.Commands;
using Order.Domain.Events;
using Order.Domain.Interfaces;
using Order.Domain.Queries;
using Order.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.IoC
{
    public static class InjectionHelper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IOrderAppService, OrderAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<OrderCreatedEvent>, OrderCreatedEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<CreateOrderCommand, bool>, CreateOrderCommandHandler>();

            // Domain - Queries
            services.AddScoped<IRequestHandler<GetOrderByIdQuery, string>, GetOrderByIdQueryHandler>();

            // Infra - Data
            services.AddScoped<IOrderRepository, OrderRepository>();
        }
    }
}
