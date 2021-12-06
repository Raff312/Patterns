using Project2.Models;

namespace Project2.MongoDb.Repositories {
    public class SubjectRepository : DataRepository<Subject>, ISubjectRepository {
        public SubjectRepository(IDataContext context) : base(context, "subjects") {
        }
    }
}
