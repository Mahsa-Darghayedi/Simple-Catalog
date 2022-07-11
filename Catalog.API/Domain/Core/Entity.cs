namespace Catalog.API.Domain.Core
{
    public class Entity<Key> : IEntity<Key>
    {
        public Key Id { get; set; }
     
    }
}
