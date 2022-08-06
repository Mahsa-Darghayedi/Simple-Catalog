using Catalog.API.Domain;
using Catalog.API.Application.Models.ProductDTOs;
using AutoMapper;
using Catalog.API.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Catalog.API.Infrastructure.Repositories.Contract;
using Catalog.API.Infrastructure.Repositories.Contract.Base;
using Catalog.API.Domain.Specifications.ProductSpecifications;
using Catalog.API.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

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

        public async Task DeleteProductAsync(int id)
        {
            var model = await _productRepository.GetByIdAsync(id);
            if (model == null) throw new InvalidOperationException("Invalid Request");

            await DeleteAsync(model);
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

        public async Task<List<ProductDetailDTO>> SearchProduct(SearchProductDTO searchDTO)
        {

            var result = _productRepository.GetQuery().AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchDTO.FilterStr))
                result = result.Specify(new ProductContainStringSpecification(searchDTO.FilterStr));

            if (searchDTO.MinPrice > 0)
                result = result.Specify(new ProductPriceMinBySpecification(searchDTO.MinPrice));

            if (searchDTO.MaxPrice > 0)
                result = result.Specify(new ProductPriceMaxBySpecification(searchDTO.MaxPrice));

            if (!string.IsNullOrWhiteSpace(searchDTO.SortBy))
            {
                var sortFilter = searchDTO.SortBy;
                if (searchDTO.IsAsc)
                    result = result.AddSorting(SortDirection.Ascending, propertyName: sortFilter);
                else
                    result = result.AddSorting(SortDirection.Descending, sortFilter);
            }


            return _mapper.Map<List<ProductDetailDTO>>(result);
        }

        public async Task<bool> UpdateProductAsync(int id, ProductCreationDTO product)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(nameof(product));
                Product newProduct = _mapper.Map<Product>(product);
                newProduct.Id = id;
                ArgumentNullException.ThrowIfNull(nameof(newProduct));
                await UpdateAsync(newProduct);
                return true;
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }
    }
}
