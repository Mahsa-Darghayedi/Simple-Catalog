namespace Catalog.API.Domain.Specifications.ProductSpecifications
{
    public class ProductPriceMaxBySpecification : BaseSpecifcation<Product>
    {
        public ProductPriceMaxBySpecification(int max)
        {
            Criteria = product => product.Price <= max;
        }
    }
}
