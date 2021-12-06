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

        public async Task CreateAsync<T>(string collection, T entity) where T : PersistableEntity {
            await GetCollection<T>(collection).InsertOneAsync(entity);
        }

        public async Task<bool> DeleteAsync<T>(string collection, Guid id) where T : PersistableEntity {
            var result = await GetCollection<T>(collection).DeleteOneAsync(x => x.Id == id).ConfigureAwait(false);
            return result.DeletedCount > 0;
        }

        public async Task<bool> DeleteAsync<T>(string collection, T entity) where T : PersistableEntity {
            var result = await DeleteAsync<T>(collection, entity.Id);
            return result;
        }

        public async Task<T?> GetByIdAsync<T>(string collection, Guid id) where T : PersistableEntity {
            return await GetCollection<T>(collection).Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IList<T>> ListAllAsync<T>(string collection) where T : PersistableEntity {
            return await GetCollection<T>(collection).Find(x => true).ToListAsync(); 
        }

        public async Task UpdateAsync<T>(string collection, T entity) where T : PersistableEntity {
            await GetCollection<T>(collection).FindOneAndReplaceAsync(x => x.Id == entity.Id, entity);
        }
    }

    public class MongoDatabaseOptions {
        public string? ConnectionString { get; set; }
    }
}
