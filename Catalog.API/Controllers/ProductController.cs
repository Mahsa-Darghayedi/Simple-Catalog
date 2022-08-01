

using Microsoft.AspNetCore.Mvc;
using Catalog.API.Application.Models.ProductDTOs;
using Catalog.API.Domain;
using Catalog.API.Application.Contracts;

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
        [Route("GetProducts")]
        public async Task<ActionResult<List<ProductSummeryDTO>>> GetProducts()
        {

            var result = await _productService.GetAllProductsAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<ActionResult<bool>> AddProduct([FromBody] ProductCreationDTO product)
        {
            await _productService.AddProductAsync(product);
            return Ok(product);
        }

        [HttpGet]
        [Route("GetProductByID")]
        public async Task<ActionResult<ProductSummeryDTO>> GetProductByID(int id)
        {
            return await _productService.GetProductByIdAsync(id);
        }

    }
}