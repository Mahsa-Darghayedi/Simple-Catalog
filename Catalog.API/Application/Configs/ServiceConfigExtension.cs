using Catalog.API.Application.Contracts;
using Catalog.API.Application.Implementation;
using Catalog.API.Infrastructure.Persistent.Extension;
using Catalog.API.Infrastructure.Repositories.Contract;
using Catalog.API.Infrastructure.Repositories.Contract.Base;
using Catalog.API.Infrastructure.Repositories.Implementiaion;
using Catalog.API.Infrastructure.Repositories.Implementiaion.Base;
using System.Reflection;

namespace Catalog.API.Application.Configs
{
    public static class ServiceConfigExtension
    {
        public static IServiceCollection AddServiceConfig(this IServiceCollection services, string connectionString)
        {
            services.AddCatalogDBContextConfig(connectionString);
            var assembly = Assembly.GetExecutingAssembly();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHttpClient();
            services.AddTransient<IUnitOfWork, UnitOfWork>();  
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddAutoMapper(assembly);

            return services;    
        }
    }
}
