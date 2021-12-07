using MongoDB.Driver;
using Project2.MongoDb;
using Project2.MongoDb.Repositories;

namespace Project2.IoC {
    public static class RegistrationHelpers {
        public static IServiceCollection AddMongoDb(this IServiceCollection services) {
            services.AddSingleton(typeof(IMongoDatabase), x => {
                var opts = x.GetService<MongoDatabaseOptions>();
                return DataLayerConfiguration.GetDatabase(opts!.ConnectionString!);
            });
            services.AddSingleton<IDataContext, MongoDbDataContext>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services) {
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
