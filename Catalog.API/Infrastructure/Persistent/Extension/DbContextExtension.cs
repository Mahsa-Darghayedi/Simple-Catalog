using Catalog.API.Infrastructure.Persistent.Context;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure.Persistent.Extension
{
    public static class DbContextExtension
    {
        public static IServiceCollection AddCatalogDBContextConfig(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CatalogDBContext>(opt => opt.UseSqlServer(connectionString));
            return services;
        }

    }
}
