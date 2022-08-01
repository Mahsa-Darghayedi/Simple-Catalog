namespace Catalog.API.Application.Contracts
{
    public interface IEntityService<T> : IDisposable where T : class
    {
        Task CreateAsync(T entity);
    }
}
