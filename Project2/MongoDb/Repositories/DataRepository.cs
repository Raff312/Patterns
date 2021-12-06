using Project2.Models;

namespace Project2.MongoDb.Repositories {
    public abstract class DataRepository<T> : IRepository<T> where T : PersistableEntity {
        protected readonly IDataContext Context;
        protected readonly string Collection;

        protected DataRepository(IDataContext context, string collection) {
            Context = context;
            Collection = collection;
        }

        public async Task<T> CreateAsync(T entity) {
            await Context.CreateAsync(Collection, entity).ConfigureAwait(false);
            return entity;
        }

        public Task<bool> DeleteAsync(Guid id) {
            return Context.DeleteAsync<T>(Collection, id);
        }

        public Task<bool> DeleteAsync(T entity) {
            return Context.DeleteAsync(Collection, entity);
        }

        public async Task<T?> GetByIdAsync(Guid id) {
            if (id == Guid.Empty) {
                return default;
            }

            return await Context.GetByIdAsync<T>(Collection, id).ConfigureAwait(false);
        }

        public async Task<IList<T>> ListAllAsync() {
            return await Context.ListAllAsync<T>(Collection).ConfigureAwait(false);
        }

        public async Task<T> UpdateAsync(T entity) {
            await Context.UpdateAsync(Collection, entity).ConfigureAwait(false);
            return entity;
        }
    }
}
