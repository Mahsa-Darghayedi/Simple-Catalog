using Catalog.API.Domain;
using Catalog.API.Infrastructure.Persistent.Context;
using Catalog.API.Infrastructure.Repositories.Contract;
using Catalog.API.Infrastructure.Repositories.Contract.Base;
using Catalog.API.Infrastructure.Repositories.Implementiaion.Base;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure.Repositories.Implementiaion
{
    public class ProductRepository : GenericRepository<Product>,  IProductRepository
    {
        public ProductRepository(CatalogDBContext context) : base(context)
        {
        }
    }
}
