using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UserManagement.Domain;
using UserManagement.Domain.BaseEntities;

namespace UserManagement.Infrastructure
{
    public class BaseRepository<T> where T : BaseEntity
    {

        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.Where(x => x.Status == Status.Active)
                               .ToListAsync(cancellationToken);
        }

        public async Task<T> GetAsync(CancellationToken cancellationToken, int id)
        {
            return await _dbSet.Where(x => x.Id == id && (x.Status == Status.Active))
                               .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> CreateAsync(CancellationToken cancellationToken, T entity)
        {
            await _dbSet.AddAsync(entity, cancellationToken);

            var changes = await _context.SaveChangesAsync(cancellationToken);
            return changes > 0;
        }

        public async Task<bool> DeleteAsync(CancellationToken cancellationToken, int id)
        {
            var entity = await GetAsync(cancellationToken, id);

            if (entity == null)
            {
                return false;
            }

            entity.Status = Status.Deleted;

            _dbSet.Update(entity);

            var changes = await _context.SaveChangesAsync(cancellationToken);
            return changes > 0;
        }

        public Task<bool> AnyAsync(CancellationToken cancellationToken, Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AnyAsync(predicate, cancellationToken);
        }
    }
}
