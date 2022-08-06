using Catalog.API.Domain;
using Catalog.API.Domain.Core;
using Catalog.API.Domain.Specifications;
using Catalog.API.Infrastructure.Repositories.Contract.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Catalog.API.Infrastructure.Repositories.Implementiaion.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {

        protected DbContext _context;
        protected readonly DbSet<T> _dbSet;


        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<T> GetAll() => _dbSet.ToList();

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T?> GetByIdAsync(int id) => await _dbSet.SingleOrDefaultAsync(c => c.Id != 0 && c.Id.Equals(id));

        public T? GetById(int id) => _dbSet.SingleOrDefault(c => c.Id != 0 && c.Id.Equals(id));

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

        }

        public Task DeleteAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> FilterAsync(string filter)
        {
            return await _dbSet.Where(filter).ToListAsync();
        }

        public IQueryable<T> GetQuery()
        {
            return _dbSet.AsQueryable<T>();
        }
    }
}
