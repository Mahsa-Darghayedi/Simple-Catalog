using Catalog.API.Domain;
using Catalog.API.Infrastructure.Data_Persistence.Contract;
using Catalog.API.Infrastructure.Data_Persistence.Repositories;

namespace Catalog.API.Infrastructure.Data_Persistence.ContractImplementiaion
{
    public class ProductRepository : GenericRepository<int, Product>, IProductRepository
    {

    }
}
