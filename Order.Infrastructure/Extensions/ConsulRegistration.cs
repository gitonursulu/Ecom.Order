//using Consul;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting.Server.Features;
//using Microsoft.AspNetCore.Http.Features;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;

using Consul;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Order.Infrastructure.Extensions
{
    public static class ConsulRegistration
    {
        public static IServiceCollection ConfigureConsul(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
            {
                var address = configuration["ConsulConfig:Address"];
                consulConfig.Address = new Uri(address);
            }));

            return services;
        }

        //public static IApplicationBuilder RegisterWithConsul(this IApplicationBuilder app, IHostApplicationLifetime lifetime)
        //{
        //    var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();

        //    var loggingFactory = app.ApplicationServices.GetRequiredService<ILoggerFactory>();

        //    var logger = loggingFactory.CreateLogger<IApplicationBuilder>();

        //    //get server ip address
        //    var features = app.Properties["server.Features"] as FeatureCollection;
        //    var addresses = features.Get<IServerAddressesFeature>();
        //    if (addresses.Addresses.Count == 0)
        //    {
        //        addresses.Addresses.Add("http://localhost:5000"); // Add the default address to the IServerAddressesFeature
        //    }
        //    var address = addresses.Addresses.First();

        //    var uri = new Uri(address);

        //    var registration = new AgentServiceRegistration()
        //    {
        //        ID = $"OrderService",
        //        Name = "OrderService",
        //        Address = $"{uri.Host}",
        //        Port = uri.Port,
        //        Tags = new[] { "Order Service", "Order" }
        //    };

        //    logger.LogInformation("Registring with consul");

        //    consulClient.Agent.ServiceDeregister(registration.ID).Wait();
        //    consulClient.Agent.ServiceRegister(registration).Wait();

        //    lifetime.ApplicationStopping.Register(() =>
        //    {
        //        logger.LogInformation("deregistering from consul");
        //        consulClient.Agent.ServiceDeregister(registration.ID).Wait();
        //    });

        //    return app;
        //}
    }
}
