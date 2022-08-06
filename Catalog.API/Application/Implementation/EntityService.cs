using Catalog.API.Application.Contracts;
using Catalog.API.Domain.Core;
using Catalog.API.Infrastructure.Repositories.Contract.Base;

namespace Catalog.API.Application.Implementation
{
    public class EntityService<T> : IEntityService<T> where T : Entity
    {

        readonly IUnitOfWork _unitOfWork;
        readonly IGenericRepository<T> _repository;

        public EntityService(IUnitOfWork unitOfWork, IGenericRepository<T> genericRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = genericRepository;
        }
        public async Task CreateAsync(T entity)
        {
            try
            {
                await _repository.AddAsync(entity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteAsync(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            await _repository.DeleteAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public void Dispose()
        {
            if (_unitOfWork != null)
            {
                _unitOfWork.Dispose();
                _repository.Dispose();
            }
        }

        public async Task UpdateAsync(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}
