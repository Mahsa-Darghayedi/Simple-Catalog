using AutoMapper;
using Catalog.API.Application.Models.ProductDTOs;
using Catalog.API.Domain;

namespace Catalog.API.Infrastructure.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductSummeryDTO>();
            CreateMap<ProductCreationDTO, Product>();
            CreateMap<Product, ProductDetailDTO>();
        }
    }
}
