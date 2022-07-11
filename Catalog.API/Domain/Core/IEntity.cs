namespace Catalog.API.Domain.Core
{
    public interface IEntity<Key>
    {
        Key Id { get; set; }
    }
}
