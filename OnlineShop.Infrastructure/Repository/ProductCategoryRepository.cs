﻿using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Interfaces.Repository;
using OnlineShop.Core.Model;
using OnlineShop.Infrastructure.Data;

namespace OnlineShop.Infrastructure.Repository;

public class ProductCategoryRepository : IProductCategoryRepository
{

    private readonly OnlineShopDbContext _dbContext;

    public ProductCategoryRepository(OnlineShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<ProductCategory?> GetByName(string name)
    {
        // ReSharper disable once StringLiteralTypo
        return _dbContext.ProductCategories
            .FromSql<ProductCategory>($"SELECT * FROM product_category WHERE name ILIKE {name}")
            .FirstOrDefaultAsync();
    }

    public Task<ProductCategory?> GetByIdAsync(int id)
    {
        return _dbContext.ProductCategories.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public Task<List<ProductCategory>> GetAllAsync()
    {
        return _dbContext.ProductCategories.ToListAsync();
    }

    public Task<IReadOnlyList<ProductCategory>> GetAllReadOnlyAsync()
    {
        return Task.FromResult<IReadOnlyList<ProductCategory>>(_dbContext.ProductCategories.ToList().AsReadOnly());
    }

    public Task<ProductCategory> InsertAsync(ProductCategory entity)
    {
        return Task.FromResult(_dbContext.ProductCategories.AddAsync(entity).Result.Entity);
    }

    public Task<ProductCategory> UpdateAsync(ProductCategory entity)
    {
        return Task.FromResult(_dbContext.ProductCategories.Update(entity).Entity);
    }

    public Task<ProductCategory> DeleteAsync(ProductCategory entity)
    {
        return Task.FromResult(_dbContext.ProductCategories.Remove(entity).Entity);
    }
}