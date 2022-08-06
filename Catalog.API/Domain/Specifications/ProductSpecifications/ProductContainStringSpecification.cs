namespace Catalog.API.Domain.Specifications.ProductSpecifications
{
    public class ProductContainStringSpecification :BaseSpecifcation<Product>
    {
        public ProductContainStringSpecification(string text)
        {
            Criteria = i=> i.Name.Contains(text) || i.Description.Contains(text);
        }
    }
}
