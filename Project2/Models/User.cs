namespace Project2.Models {
    public class User : PersistableEntity {
        public UserType UserType { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<Guid>? SubjectIds { get; set; }
        public Dictionary<Guid, Dictionary<Guid, int>>? SubjectPoints { get; set; }

        public void Update(User entity) {
            FirstName = entity.FirstName;
            SecondName = entity.SecondName;
            MiddleName = entity.MiddleName;
            Username = entity.Username;
            Password = entity.Password;
            SubjectIds = entity.SubjectIds;
            SubjectPoints = entity.SubjectPoints;
            UserType = entity.UserType;
        }
    }
}
