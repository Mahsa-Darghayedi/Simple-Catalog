using Catalog.API.Domain.Core;

namespace Catalog.API.Infrastructure.Data_Persistence.Core
{
    public interface IGenericRepository<Key, T> where T : IEntity<Key>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllAsync();
        void Add(T entity); 

    }
}
