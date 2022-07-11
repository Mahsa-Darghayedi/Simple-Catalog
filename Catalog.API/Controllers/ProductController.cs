
using Microsoft.AspNetCore.Mvc;
using Catalog.API.Application.Contracts.Interface;
using Catalog.API.Application.Models.ProductDTOs;
using Catalog.API.Domain;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("Products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductSummeryDTO>>> GetProducts()
        {
            var result = await _productService.GetAllProductsAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddProduct([FromBody] ProductCreationDTO product)
        {
            await _productService.AddProductAsync(product);
            return Ok(product);
        }

    }
}