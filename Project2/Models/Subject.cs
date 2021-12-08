namespace Project2.Models {
    public class Subject : PersistableEntity {
        public string Name { get; set; } = string.Empty;
        public bool IsExam { get; set; }
        public List<Checkpoint>? Checkpoints { get; set; }

        public void Update(Subject entity) {
            Name = entity.Name;
            IsExam = entity.IsExam;
        }
    }
}
