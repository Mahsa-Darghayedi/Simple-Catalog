namespace Catalog.API.Domain.Specifications.ProductSpecifications
{
    public class ProductPriceMinBySpecification : BaseSpecifcation<Product>
    {
        public ProductPriceMinBySpecification(int min)
        {
            Criteria = product => product.Price >= min;
        }
    }
}
