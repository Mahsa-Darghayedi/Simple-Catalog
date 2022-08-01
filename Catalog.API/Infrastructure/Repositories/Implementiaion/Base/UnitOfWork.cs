using Catalog.API.Infrastructure.Persistent.Context;
using Catalog.API.Infrastructure.Repositories.Contract.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Catalog.API.Infrastructure.Repositories.Implementiaion.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;
        private IDbContextTransaction? _transaction = null;

        public UnitOfWork(CatalogDBContext dbContext)
        {
            _dbContext = dbContext;
            _transaction = _dbContext.Database.BeginTransaction();
        }
        public async Task CommitAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                _transaction?.Commit();
            }
            catch (Exception ex)
            {
                _transaction?.Rollback();
                throw;
            }
            finally
            {
                _transaction = _dbContext.Database.BeginTransaction();
            }
        }

        public void Dispose()
        {

            if (_dbContext != null)
            {
                _transaction?.Dispose();
                _dbContext.Dispose();
                _dbContext = null;
            }
        }
    }
}
