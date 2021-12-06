namespace Project2.Models {
    public class User : PersistableEntity {
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public List<Permission> Permissions { get; set; } = new List<Permission>();
        public List<Subject>? Subjects { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
