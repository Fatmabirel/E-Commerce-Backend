using e_commerce_backend.Application.Repositories;
using e_commerce_backend.Domain.Entities.Common;
using e_commerce_backend.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace e_commerce_backend.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ECommerceDbContext _context;
        public ReadRepository(ECommerceDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
            => Table;
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
            => Table.Where(method);
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
            => await Table.FirstOrDefaultAsync(method);

        public async Task<T> GetByIdAsync(string id)
           // => await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
           => await Table.FindAsync(Guid.Parse(id));

    }
}
