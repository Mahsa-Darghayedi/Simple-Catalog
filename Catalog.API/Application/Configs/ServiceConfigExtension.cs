using Catalog.API.Application.Contract.Implementation;
using Catalog.API.Application.Contract.Interface;
using Catalog.API.Domain;
using Catalog.API.Infrastructure.Data_Persistence.Contract;
using Catalog.API.Infrastructure.Data_Persistence.ContractImplementiaion;
using Catalog.API.Infrastructure.Data_Persistence.Core;
using Catalog.API.Infrastructure.Data_Persistence.Repositories;

namespace Catalog.API.Application.Configs
{
    public static class ServiceConfigExtension
    {
        public static IServiceCollection AddServiceConfig(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            return services;    
        }
    }
}
