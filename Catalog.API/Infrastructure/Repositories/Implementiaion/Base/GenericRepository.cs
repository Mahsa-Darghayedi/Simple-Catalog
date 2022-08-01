using Catalog.API.Domain;
using Catalog.API.Domain.Core;
using Catalog.API.Infrastructure.Repositories.Contract.Base;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure.Repositories.Implementiaion.Base
{
    public class GenericRepository< T> : IGenericRepository<T> where T : Entity
    {

        protected DbContext _context;
        protected readonly DbSet<T> DbSet;


        public GenericRepository(DbContext context)
        {
            _context = context;
            DbSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            DbSet.Add(entity);
            _context.SaveChanges();
        }
        public async Task AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<T> GetAll() => DbSet.ToList();

        public async Task<IEnumerable<T>> GetAllAsync() => await DbSet.ToListAsync();

        public async Task<T?> GetByIdAsync(int id) => await DbSet.SingleOrDefaultAsync(c => c.Id != 0 && c.Id.Equals(id));

        public T? GetById(int id) => DbSet.SingleOrDefault(c => c.Id != 0 && c.Id.Equals(id));

        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose(); 
                _context = null;    
            }
        }
    }
}
