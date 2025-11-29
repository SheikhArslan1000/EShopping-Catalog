using Catalog.Application.Persistance;
using Catalog.Domain.ProductsDetails;
using Catalog.Infrastructure.DataBaseContext;
using Catalog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using MediatR;
using System.Reflection;

using Shared.Application.Persistance;

namespace Catalog.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<CatalogDatabaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("CatalogDataBaseConnectionstring")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepositry<>));

            services.AddScoped<IProductDetailsRepositories, ProductDetailsRepository>();
            services.AddScoped<IAuditTrailRepository, AuditTrailRepository>();

            //services.AddScoped<INotificationHandler<EntityUpdatedEvent<Product>>, EntityUpdatedEventHandler<Product>>();

            //builde.AddMediatR(typeof(EntityUpdatedEventHandler<>).Assembly);
            //          services.AddSingleton<Func<EntityUpdatedEvent<Product>, (string, object)>>(
            //    new Func<EntityUpdatedEvent<Product>, (string, object)>(evt =>
            //        (
            //           // evt.EntityId,
            //            evt.ChangeType,
            //            (object)evt.Entity!
            //           // evt.TableName
            //        ))
            //);
            //services.AddTransient<
            //    INotificationHandler<EntityChangedEvent<AuditTrail>>,
            //    GenericAuditTrailHandler<EntityChangedEvent<AuditTrail>, AuditTrail>>();

            //services.AddTransient<
            //    INotificationHandler<EntityChangedEvent<AuditTrail>>,
            //    GenericAuditTrailHandler<EntityChangedEvent<AuditTrail>, AuditTrail>>();
            //services.AddScoped(typeof(INotificationHandler<>), typeof(GenericAuditTrailHandler<,>));
            //services.AddDomainEventHandlers(Assembly.GetExecutingAssembly());
            //services.AddScoped<INotificationHandler<EntityChangedEvent<Product>>, GenericAuditTrailHandler<EntityChangedEvent<Product>, Product>>();

            DatabaseConfiguration(services, configuration);
            return services;
        }

        public static void DatabaseConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            // Data base configuration
            services.AddDbContext<CatalogDatabaseContext>(options =>
             options.UseSqlServer(
                    configuration.GetConnectionString("CatalogDataBaseConnectionstring"), sqloptions =>
                    {
                        sqloptions.MigrationsAssembly("Catalog.Infrastructure");
                    })
                );
            //var optionsBuilder = new DbContextOptionsBuilder<CatalogDatabaseContext>();

            //optionsBuilder.UseSqlServer(
            //    configuration.GetConnectionString("CatalogDatabaseContext"),
            //    sql => sql.MigrationsAssembly("Catalog.Infrastructure")
            //);
        }

    }
}
