using e_commerce_backend.Application.Repositories;
using e_commerce_backend.Domain.Entities;
using e_commerce_backend.Persistence.Context;

namespace e_commerce_backend.Persistence.Repositories
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
