using Catalog.API.Domain;
using Microsoft.AspNetCore.Mvc;
using Catalog.API.Application.Contract.Interface;

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
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var result = await _productService.GetAllProductsAsync();   
            return Ok(result);  
        }
   
    }
}