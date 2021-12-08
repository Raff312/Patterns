namespace Project2.Models {
    public class Checkpoint : PersistableEntity {
        public string Name { get; set; } = "-";
        public int MaxPoint { get; set; }

        public Checkpoint() {
            GenerateId();
        }
    }
}
