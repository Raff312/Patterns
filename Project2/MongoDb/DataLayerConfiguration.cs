using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Project2.Models;

namespace Project2.MongoDb {
    public static class DataLayerConfiguration {
        public static bool Configured { get; private set; }
        private static readonly object _locker = new object();

        public static IMongoDatabase GetDatabase(string connectionString) {
            var url = MongoUrl.Create(connectionString);
            var client = new MongoClient(connectionString);
            return client.GetDatabase(url.DatabaseName);
        }

        public static void Configure() {
            if (Configured) {
                return;
            }

            lock (_locker) {
                if (Configured) {
                    return;
                }

                ConfigureSubject();
                ConfigureUser();

                Configured = true;
            }
        }

        private static void ConfigureSubject() {
            BsonClassMap.RegisterClassMap<Subject>(cm => {
                cm.AutoMap();
                cm.MapProperty(x => x.Checkpoints).SetIgnoreIfDefault(true);
            });

            BsonClassMap.RegisterClassMap<Checkpoint>(cm => {
                cm.AutoMap();
                cm.MapProperty(x => x.Date).SetIgnoreIfDefault(true);
                cm.MapProperty(x => x.CurrentPoint).SetIgnoreIfDefault(true);
            });
        }

        private static void ConfigureUser() {
            BsonClassMap.RegisterClassMap<User>(cm => {
                cm.AutoMap();
                cm.MapProperty(x => x.SubjectIds).SetIgnoreIfDefault(true);
                cm.MapProperty(x => x.SubjectPoints).SetIgnoreIfDefault(true);
            });
        }
    }
}
