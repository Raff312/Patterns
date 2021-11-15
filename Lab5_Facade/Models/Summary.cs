namespace Lab5_Facade.Models {
    public class Summary {
        public void GetSummary() {
            var square = Utils.Utils.GetValueFromUser<double>("Enter square: ");
            var insuranceTerm = Utils.Utils.GetValueFromUser<int>("Enter insurance term: ");
            var residentsCount = Utils.Utils.GetValueFromUser<int>("Enter residents count: ");
            var year = Utils.Utils.GetValueFromUser<int>("Enter year: ");
            var wear = Utils.Utils.GetValueFromUser<double>("Enter wear: ");
        
            var flat = new Flat(square, insuranceTerm, residentsCount, year, wear);
            var townHouse = new TownHouse(square, insuranceTerm, residentsCount, year, wear);
            var cottage = new Cottage(square, insuranceTerm, residentsCount, year, wear);
        
            Console.WriteLine($"\nFlat fee = {flat.CalculateFee()}");
            Console.WriteLine($"Townhouse fee = {townHouse.CalculateFee()}");
            Console.WriteLine($"Cottage fee = {cottage.CalculateFee()}");
        }
    }
}