using OnlineShop.Core.Model;

namespace OnlineShop.Core.Interfaces.Service;

public interface IProductService
{
    Task<List<Product>> GetAllProductsAsync();
}