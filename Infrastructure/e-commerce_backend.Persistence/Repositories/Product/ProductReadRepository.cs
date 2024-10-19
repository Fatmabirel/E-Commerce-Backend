using e_commerce_backend.Application.Repositories;
using e_commerce_backend.Domain.Entities;
using e_commerce_backend.Persistence.Context;

namespace e_commerce_backend.Persistence.Repositories
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
