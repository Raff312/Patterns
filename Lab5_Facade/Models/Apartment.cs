namespace Lab5_Facade.Models {
    public abstract class Apartment {
        protected double Square { get; set; } = 35.0;
        protected int InsuranceTerm { get; set; } = 10;
        protected int ResidentsCount { get; set; } = 0;
        protected int Year { get; set; } = 2020;
        protected double Wear { get; set; } = 0.0;

        protected Apartment(double square, int term, int count, int year, double wear) {
            Square = square;
            InsuranceTerm = term;
            ResidentsCount = count;
            Year = year;
            Wear = wear;
        }

        public void GetInfoFromUser() {
            Square = Utils.Utils.GetValueFromUser<double>("Enter square: ");
            InsuranceTerm = Utils.Utils.GetValueFromUser<int>("Enter insurance term: ");
            ResidentsCount = Utils.Utils.GetValueFromUser<int>("Enter residents count: ");
            Year = Utils.Utils.GetValueFromUser<int>("Enter year: ");
            Wear = Utils.Utils.GetValueFromUser<double>("Enter wear: ");
        }

        public abstract double CalculateFee();
    }
}