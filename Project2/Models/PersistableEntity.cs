namespace Project2.Models {
    public abstract class PersistableEntity : IManualIdentity {

        public Guid Id { get; protected set; }
                
        void IManualIdentity.SetId(Guid id) {
            Id = id;
        }

        public void GenerateId() {
            Id = Guid.NewGuid();
        }
    }
}
