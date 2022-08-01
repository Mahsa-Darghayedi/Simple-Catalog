using Catalog.API.Domain;
using Catalog.API.Application.Models.ProductDTOs;
using AutoMapper;
using Catalog.API.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Catalog.API.Infrastructure.Repositories.Implementiaion;
using Microsoft.EntityFrameworkCore;
using Catalog.API.Infrastructure.Repositories.Contract;
using Catalog.API.Infrastructure.Persistent.Context;
using Catalog.API.Infrastructure.Repositories.Contract.Base;

namespace Catalog.API.Application.Implementation
{
    public class ProductService : EntityService<Product>, IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public ProductService(IUnitOfWork unitOfWork,
                             IProductRepository productRepository,
                             IMapper mapper) : base(unitOfWork, productRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public async Task<bool> AddProductAsync(ProductCreationDTO productCreationDTO)
        {
            var product = _mapper.Map<Product>(productCreationDTO);
            await CreateAsync(product);
            return true;
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAll().ToList();
        }

        public async Task<List<ProductSummeryDTO>> GetAllProductsAsync()
        {
            var result = await _productRepository.GetAllAsync();
            return _mapper.Map<List<ProductSummeryDTO>>(result);
        }

        public async Task<ActionResult<ProductSummeryDTO>> GetProductByIdAsync(int id)
        {
            var result = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductSummeryDTO>(result);
        }
    }
}
