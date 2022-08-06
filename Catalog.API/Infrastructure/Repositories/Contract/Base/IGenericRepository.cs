using Catalog.API.Domain.Core;
using Catalog.API.Domain.Specifications;
using System.Linq.Expressions;

namespace Catalog.API.Infrastructure.Repositories.Contract.Base
{
    public interface IGenericRepository<T> : IDisposable where T : Entity
    {
        IEnumerable<T> GetAll();
        IQueryable<T> GetQuery();
        Task<IEnumerable<T>> GetAllAsync();
        void Add(T entity);
        Task AddAsync(T entity);

        Task<T?> GetByIdAsync(int id);
        T? GetById(int id);

        void Update(T entity);

        Task DeleteAsync(T entity);

        Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FilterAsync(string filter);
    }
}
