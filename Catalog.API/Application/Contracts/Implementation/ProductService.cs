using Catalog.API.Domain;
using Catalog.API.Infrastructure.Data_Persistence.Repositories;
using Catalog.API.Infrastructure.Data_Persistence.ContractImplementiaion;
using Catalog.API.Application.Contracts.Interface;
using Catalog.API.Application.Models.ProductDTOs;
using AutoMapper;

namespace Catalog.API.Application.Contracts.Implementation
{
    public class ProductService : ProductRepository, IProductService
    {
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<bool> AddProductAsync(ProductCreationDTO productCreationDTO)
        {
            var product = _mapper.Map<Product>(productCreationDTO);
            Add(product);
            return await Task.FromResult(true);
        }

        public List<Product> GetAllProducts()
        {
            return GetAll().ToList();
        }

        public async Task<List<ProductSummeryDTO>> GetAllProductsAsync()
        {
            var result = await Task.FromResult(GetAllAsync());
            return _mapper.Map<List<ProductSummeryDTO>>(result);
        }
    }
}
