using e_commerce_backend.Domain.Entities;

namespace e_commerce_backend.Application.Abstractions
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}
