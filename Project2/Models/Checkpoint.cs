namespace Project2.Models {
    public class Checkpoint : PersistableEntity {
        public DateTime? Date { get; set; }
        public string Name { get; set; } = "-";
        public int MaxPoint { get; set; }
        public int? CurrentPoint { get; set; }
    }
}
