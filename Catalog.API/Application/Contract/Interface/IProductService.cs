using Catalog.API.Domain;

namespace Catalog.API.Application.Contract.Interface
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Task<List<Product>> GetAllProductsAsync();
    }
}
