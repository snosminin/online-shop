using OnlineShop.Core.Model;

namespace OnlineShop.Core.Interfaces.Repository;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAllReadOnlyAsync();
    Task<T> InsertAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}