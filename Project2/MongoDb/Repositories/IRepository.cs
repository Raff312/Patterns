using Project2.Models;

namespace Project2.MongoDb.Repositories {
    public interface IRepository {
    }

    public interface IRepository<T> : IRepository where T : PersistableEntity {
        Task<IList<T>> ListAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> DeleteAsync(T entity);
    }
}
