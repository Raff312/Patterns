namespace Project2.Models {
    public class Target {
        public DateTime? Date { get; set; }
        public string Name { get; set; } = "-";
        public int MaxPoint { get; set; }
        public int? CurrentPoint { get; set; }
        public string? Theme { get; set; } = string.Empty;
    }
}
