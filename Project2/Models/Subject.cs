namespace Project2.Models {
    public class Subject : PersistableEntity {
        public string Name { get; set; } = string.Empty;
        public bool IsExam { get; set; }
        public List<Target>? Targets { get; set; }
    }
}
