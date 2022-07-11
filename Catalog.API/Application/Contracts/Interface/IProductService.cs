using Catalog.API.Application.Models.ProductDTOs;
using Catalog.API.Domain;

namespace Catalog.API.Application.Contracts.Interface
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Task<List<ProductSummeryDTO>> GetAllProductsAsync();

        Task<bool> AddProductAsync(ProductCreationDTO product);
    }
}
