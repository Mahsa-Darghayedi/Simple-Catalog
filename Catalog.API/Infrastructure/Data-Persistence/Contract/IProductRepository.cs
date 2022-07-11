using Catalog.API.Domain;
using Catalog.API.Infrastructure.Data_Persistence.Core;

namespace Catalog.API.Infrastructure.Data_Persistence.Contract
{
    public interface IProductRepository : IGenericRepository<int,Product>
    {
    }
}
