using Project2.Models;

namespace Project2.MongoDb.Repositories {
    public abstract class DataRepository<TEntity> : IRepository<TEntity> where TEntity : PersistableEntity {
        protected readonly IDataContext Context;
        protected readonly string Collection;

        protected DataRepository(IDataContext context, string collection) {
            Context = context;
            Collection = collection;
        }

        public async Task<TEntity> CreateAsync(TEntity entity) {
            await Context.CreateAsync(Collection, entity).ConfigureAwait(false);
            return entity;
        }

        public Task<bool> DeleteAsync(Guid id) {
            return Context.DeleteAsync<TEntity>(Collection, id);
        }

        public Task<bool> DeleteAsync(TEntity entity) {
            return Context.DeleteAsync(Collection, entity);
        }

        public async Task<TEntity?> GetByIdAsync(Guid id) {
            if (id == Guid.Empty) {
                return default;
            }

            return await Context.GetByIdAsync<TEntity>(Collection, id).ConfigureAwait(false);
        }

        public async Task<IList<TEntity>> ListAllAsync() {
            return await Context.ListAllAsync<TEntity>(Collection).ConfigureAwait(false);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity) {
            await Context.UpdateAsync(Collection, entity).ConfigureAwait(false);
            return entity;
        }

        protected Task<IList<TDerived>> FindOfTypeAsync<TDerived>() where TDerived : TEntity {
            return Context.FindOfTypeAsync<TEntity, TDerived>(Collection);
        }
    }
}
