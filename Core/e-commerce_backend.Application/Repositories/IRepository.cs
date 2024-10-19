using e_commerce_backend.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_backend.Application.Repositories
{
    public interface IRepository<T> where T: BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
