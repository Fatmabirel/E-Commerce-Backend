﻿using e_commerce_backend.Domain.Entities.Common;

namespace e_commerce_backend.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }
    }
}
