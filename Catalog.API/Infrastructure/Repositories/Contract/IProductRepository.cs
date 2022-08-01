using Catalog.API.Domain;
using Catalog.API.Infrastructure.Repositories.Contract.Base;

namespace Catalog.API.Infrastructure.Repositories.Contract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
