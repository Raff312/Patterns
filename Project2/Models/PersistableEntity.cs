namespace Project2.Models {
    public abstract class PersistableEntity {
        public Guid Id { get; protected set; }

        public void GenerateId() {
            Id = Guid.NewGuid();
        }
    }
}
