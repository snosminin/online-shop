﻿using OnlineShop.Core.Model;

namespace OnlineShop.Core.Interfaces.Repository;

public interface IProductCategoryRepository : IGenericRepository<ProductCategory>
{
    Task<ProductCategory?> GetByName(string name);
}