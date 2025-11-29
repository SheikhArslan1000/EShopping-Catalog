using Catalog.Domain.ProductsDetails;
using Catalog.Infrastructure.Configurations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.Common;
using Shared.Domain.Events;

namespace Catalog.Infrastructure.DataBaseContext
{
    public class CatalogDatabaseContext : DbContext
    {
        private readonly IMediator _mediator;

        public CatalogDatabaseContext(DbContextOptions<CatalogDatabaseContext> options, IMediator mediator) : base(options) => _mediator = mediator;
        
        public DbSet<Product> Products { get; set; }
        public DbSet<AuditTrail> AuditTrails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDatabaseContext).Assembly);
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.Ignore<DomainEvent>();
            base.OnModelCreating(modelBuilder);


        }
        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    foreach (var item in base.ChangeTracker.Entries<BaseEntity>().Where(_ => _.State == EntityState.Added || _.State == EntityState.Modified))
        //    {
        //        item.Entity.DateModified = DateTime.Now;

        //        if (item.State == EntityState.Added)
        //        {
        //            item.Entity.DateCreated = DateTime.Now;
        //        }
        //    }
        //    return base.SaveChangesAsync(cancellationToken);
        //}
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var domainEvents = ChangeTracker.Entries<BaseEntity>()
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            foreach (var item in base.ChangeTracker.Entries<BaseEntity>().Where(_ => _.State == EntityState.Added || _.State == EntityState.Modified))
            {
                item.Entity.DateModified = DateTime.Now;

                if (item.State == EntityState.Added)
                {
                    item.Entity.DateCreated = DateTime.Now;
                }
            }

            using var transaction = await Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var result = await base.SaveChangesAsync(cancellationToken);

                //foreach (var domainEvent in domainEvents)
                //    await _mediator.Publish(domainEvent, cancellationToken);

                //foreach (var entry in ChangeTracker.Entries<BaseEntity>())
                //    entry.Entity.ClearDomainEvents();


                await transaction.CommitAsync(cancellationToken);
                return result;
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}
