using Catalog.Infrastructure.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Shared.Application.Persistance;
using Shared.Domain.Common;

namespace Catalog.Infrastructure.Repositories
{
    public class GenericRepositry<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly CatalogDatabaseContext _context;
        public GenericRepositry(CatalogDatabaseContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(T entity)
        {
            _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<T>> GetAsync()
        {
            return await _context.Set<T>()
                   .AsNoTracking().ToListAsync();
        }
        public async Task<T> GetById(Guid Id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(_ => _.Id == Id);
        }
        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
