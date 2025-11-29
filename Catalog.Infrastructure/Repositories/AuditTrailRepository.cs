using Catalog.Infrastructure.DataBaseContext;
using Shared.Application.Persistance;
using Shared.Domain.Events;

namespace Catalog.Infrastructure.Repositories
{
    public class AuditTrailRepository : IAuditTrailRepository
    {
        private readonly CatalogDatabaseContext _context;
        public AuditTrailRepository(CatalogDatabaseContext context) => _context = context;

        public async Task SaveAsync(AuditTrail entry)
        {
            _context.AuditTrails.Add(entry);
            await _context.SaveChangesAsync();
        }
    }
}
