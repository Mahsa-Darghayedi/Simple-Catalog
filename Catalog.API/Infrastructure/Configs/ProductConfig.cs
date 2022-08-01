using Catalog.API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.API.Infrastructure.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Id).IsRequired().UseHiLo();
            builder.Property(x=> x.Name).IsRequired().IsUnicode().HasMaxLength(200);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x=> x.Description).IsRequired(false).IsUnicode().HasMaxLength(500);

        }
    }
}
