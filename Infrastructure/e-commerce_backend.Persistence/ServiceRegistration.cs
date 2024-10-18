using e_commerce_backend.Application.Abstractions;
using e_commerce_backend.Persistence.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace e_commerce_backend.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductService, ProductService>();
        }
    }
}
