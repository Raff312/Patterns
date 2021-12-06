using Project2.Models;

namespace Project2.MongoDb.Repositories {
    public interface IDataContext {
        Task<IList<T>> ListAllAsync<T>(string collection) where T : PersistableEntity;
        Task<T?> GetByIdAsync<T>(string collection, Guid id) where T : PersistableEntity;
        Task CreateAsync<T>(string collection, T entity) where T : PersistableEntity;
        Task UpdateAsync<T>(string collection, T entity) where T : PersistableEntity;
        Task<bool> DeleteAsync<T>(string collection, Guid id) where T : PersistableEntity;
        Task<bool> DeleteAsync<T>(string collection, T entity) where T : PersistableEntity;
    }
}
