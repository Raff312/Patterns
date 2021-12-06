namespace Project2.Models {
    public interface IManualIdentity {
        void SetId(Guid id);
        void GenerateId();
    }
}
