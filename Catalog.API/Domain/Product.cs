using Catalog.API.Domain.Core;

namespace Catalog.API.Domain
{
    public class Product : Entity<int>
    {
        public string Name { get; set; }
    }
}
