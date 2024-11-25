using e_commerce_backend.Application.Services;
using e_commerce_backend.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace e_commerce_backend.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IFileService, FileService>();
        }
    }
}
