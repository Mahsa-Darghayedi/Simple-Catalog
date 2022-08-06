using Catalog.API.Application.Models.ProductDTOs;
using Catalog.API.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Application.Contracts
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Task<List<ProductSummeryDTO>> GetAllProductsAsync();

        Task<bool> AddProductAsync(ProductCreationDTO product);
        Task<ActionResult<ProductSummeryDTO>> GetProductByIdAsync(int id);
        Task<bool> UpdateProductAsync(int id,ProductCreationDTO product);

        Task DeleteProductAsync(int id);

        Task<List<ProductDetailDTO>> SearchProduct(SearchProductDTO searchDTO);

    }
}
