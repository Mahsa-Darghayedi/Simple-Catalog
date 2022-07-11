using Catalog.API.Domain;
using Catalog.API.Domain.Core;
using Catalog.API.Infrastructure.Data_Persistence.Core;

namespace Catalog.API.Infrastructure.Data_Persistence.Repositories
{
    public class GenericRepository<Key, T> : IGenericRepository<Key, T> where T : Entity<Key>
    {

        //protected DbContext _context;
        //protected readonly IDbSet<T> DbSet;


        //public GenericRepository(DbContext context)
        //{
        //    _context = context;
        //    DbSet = context.Set<T>();
        //}
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllAsync()
        {
           return (IEnumerable<T>)(new List<Product>() { new Product() { Id = 1, Name = "P1" }, new Product() { Id = 2, Name = "P2" } }).AsEnumerable();

           // throw new NotImplementedException();
        }
    }
}
