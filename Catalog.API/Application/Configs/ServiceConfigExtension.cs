using Catalog.API.Application.Contracts.Implementation;
using Catalog.API.Application.Contracts.Interface;
using Catalog.API.Domain;
using Catalog.API.Infrastructure.Data_Persistence.Contract;
using Catalog.API.Infrastructure.Data_Persistence.ContractImplementiaion;
using Catalog.API.Infrastructure.Data_Persistence.Core;
using Catalog.API.Infrastructure.Data_Persistence.Repositories;
using System.Reflection;

namespace Catalog.API.Application.Configs
{
    public static class ServiceConfigExtension
    {
        public static IServiceCollection AddServiceConfig(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddAutoMapper(assembly);

            return services;    
        }
    }
}
