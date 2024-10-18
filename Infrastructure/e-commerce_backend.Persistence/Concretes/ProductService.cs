using e_commerce_backend.Application.Abstractions;
using e_commerce_backend.Domain.Entities;

namespace e_commerce_backend.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts() => new()
        {
            new() {Id = Guid.NewGuid(), Name = "Product1", Price = 100, Stock=100},
            new() {Id = Guid.NewGuid(), Name = "Product2", Price = 170, Stock=107},
            new() {Id = Guid.NewGuid(), Name = "Product3", Price = 150, Stock=107},
            new() {Id = Guid.NewGuid(), Name = "Product4", Price = 140, Stock=1007},
            new() {Id = Guid.NewGuid(), Name = "Product5", Price = 101, Stock=10014},
        };

    }
}
