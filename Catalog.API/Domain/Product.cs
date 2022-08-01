using Catalog.API.Domain.Core;

namespace Catalog.API.Domain
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
