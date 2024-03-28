using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
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
        public async Task<T?> GetAsync(CancellationToken cancellationToken, int id)
        {
            return await _dbSet.Where(x => x.Id == id && (x.Status == Status.Active))
                               .FirstOrDefaultAsync(cancellationToken);
        }
        public async Task CreateAsync(CancellationToken cancellationToken, T entity)
        {
            await _dbSet.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            var entity = await GetAsync(cancellationToken, id);

            if (entity == null)
            {
                return;
            }

            entity.Status = Status.Deleted;

            _dbSet.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }
        public Task<bool> AnyAsync(CancellationToken cancellationToken, Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AnyAsync(predicate, cancellationToken);
        }
    }
}
