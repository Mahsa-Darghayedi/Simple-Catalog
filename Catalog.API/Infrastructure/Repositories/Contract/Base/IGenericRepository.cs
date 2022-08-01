using Catalog.API.Domain.Core;

namespace Catalog.API.Infrastructure.Repositories.Contract.Base
{
    public interface IGenericRepository<T> : IDisposable where T : Entity
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        void Add(T entity);
        Task AddAsync(T entity);

        Task<T?> GetByIdAsync(int id);
        T? GetById(int id);

    }
}
