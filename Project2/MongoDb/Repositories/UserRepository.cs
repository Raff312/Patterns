using Project2.Models;

namespace Project2.MongoDb.Repositories {
    public class UserRepository : DataRepository<User>, IUserRepository {
        public UserRepository(IDataContext context) : base(context, "users") {
        }
    }
}
