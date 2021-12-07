using MongoDB.Driver;
using Project2.Models;

namespace Project2.MongoDb.Repositories {
    public class MongoDbDataContext : IDataContext {
        private readonly IMongoDatabase _database;

        public MongoDbDataContext(IMongoDatabase database) {
            _database = database;
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>(string collection) {
            return _database.GetCollection<TEntity>(collection);
        }

        public async Task CreateAsync<TEntity>(string collection, TEntity entity) where TEntity : PersistableEntity {
            await GetCollection<TEntity>(collection).InsertOneAsync(entity);
        }

        public async Task<bool> DeleteAsync<TEntity>(string collection, Guid id) where TEntity : PersistableEntity {
            var result = await GetCollection<TEntity>(collection).DeleteOneAsync(x => x.Id == id).ConfigureAwait(false);
            return result.DeletedCount > 0;
        }

        public async Task<bool> DeleteAsync<TEntity>(string collection, TEntity entity) where TEntity : PersistableEntity {
            var result = await DeleteAsync<TEntity>(collection, entity.Id);
            return result;
        }

        public async Task<TEntity?> GetByIdAsync<TEntity>(string collection, Guid id) where TEntity : PersistableEntity {
            return await GetCollection<TEntity>(collection).Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IList<TEntity>> ListAllAsync<TEntity>(string collection) where TEntity : PersistableEntity {
            return await GetCollection<TEntity>(collection).Find(x => true).ToListAsync(); 
        }

        public async Task UpdateAsync<TEntity>(string collection, TEntity entity) where TEntity : PersistableEntity {
            await GetCollection<TEntity>(collection).FindOneAndReplaceAsync(x => x.Id == entity.Id, entity);
        }

        public async Task<IList<TDerived>> FindOfTypeAsync<TEntity, TDerived>(string collection) where TDerived : TEntity {
            return await GetCollection<TEntity>(collection).OfType<TDerived>().Find(x => true).ToListAsync();
        }
    }

    public class MongoDatabaseOptions {
        public string? ConnectionString { get; set; }
    }
}
