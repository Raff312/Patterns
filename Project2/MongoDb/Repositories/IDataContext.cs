using Project2.Models;

namespace Project2.MongoDb.Repositories {
    public interface IDataContext {
        Task<IList<TEntity>> ListAllAsync<TEntity>(string collection) where TEntity : PersistableEntity;
        Task<TEntity?> GetByIdAsync<TEntity>(string collection, Guid id) where TEntity : PersistableEntity;
        Task CreateAsync<TEntity>(string collection, TEntity entity) where TEntity : PersistableEntity;
        Task UpdateAsync<TEntity>(string collection, TEntity entity) where TEntity : PersistableEntity;
        Task<bool> DeleteAsync<TEntity>(string collection, Guid id) where TEntity : PersistableEntity;
        Task<bool> DeleteAsync<TEntity>(string collection, TEntity entity) where TEntity : PersistableEntity;
    }
}
