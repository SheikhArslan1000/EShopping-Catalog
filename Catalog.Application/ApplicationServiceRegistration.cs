using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shared.Application.EventHandler;
using System.Reflection;

namespace Catalog.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //services.AddMediatR(_ =>
            //{
            //    _.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            //});
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());  // Application layer
                cfg.RegisterServicesFromAssembly(typeof(EntityUpdatedEventHandler<>).Assembly);  // Domain layer
            });

            services.AddTransient(typeof(INotificationHandler<>), typeof(EntityUpdatedEventHandler<>));
            return services;
        }
    }
}
