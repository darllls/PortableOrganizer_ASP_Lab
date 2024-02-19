using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using PortableOrganizer.Data.Repositories.Interfaces;
namespace PortableOrganizer.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly OrganizerDbContext _context;

        public GenericRepository(OrganizerDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<T>> GetByConditionAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().Where(condition).ToListAsync(cancellationToken);
        }

        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<bool> CreateAsync(T entity, CancellationToken cancellationToken)
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
            return (await _context.SaveChangesAsync(cancellationToken)) == 1;
        }

        public async Task<int> CreateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            await _context.Set<T>().AddRangeAsync(entities, cancellationToken);
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            _context.Set<T>().RemoveRange(entities);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        {
            _context.Set<T>().UpdateRange(entities);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
