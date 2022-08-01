using Catalog.API.Domain;
using Catalog.API.Infrastructure.Configs;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Catalog.API.Infrastructure.Persistent.Context
{
    public class CatalogDBContext : DbContext
    {
        public CatalogDBContext(DbContextOptions option) : base(option)
        {
        }


        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDBContext).Assembly);
        }
    }
}
