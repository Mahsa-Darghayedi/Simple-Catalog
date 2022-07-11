using Catalog.API.Domain;
using Catalog.API.Infrastructure.Data_Persistence.Repositories;
using Catalog.API.Infrastructure.Data_Persistence.ContractImplementiaion;
using Catalog.API.Application.Contract.Interface;

namespace Catalog.API.Application.Contract.Implementation
{
    public class ProductService : ProductRepository, IProductService
    {
        public List<Product> GetAllProducts()
        {
            return GetAll().ToList();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await Task.FromResult(GetAllAsync().ToList());
        }
    }
}
