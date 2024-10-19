﻿using e_commerce_backend.Application.Repositories;
using e_commerce_backend.Domain.Entities;
using e_commerce_backend.Persistence.Context;

namespace e_commerce_backend.Persistence.Repositories
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
