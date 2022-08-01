namespace Catalog.API.Infrastructure.Repositories.Contract.Base
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();
    }
}
