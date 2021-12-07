using Project2.Models;

namespace Project2.MongoDb.Repositories {
    public interface IRepository {
    }

    public interface IRepository<TEntity> : IRepository where TEntity : PersistableEntity {
        Task<IList<TEntity>> ListAllAsync();
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> DeleteAsync(TEntity entity);
    }
}
