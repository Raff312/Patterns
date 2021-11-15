namespace Lab5_Facade.Models {
    public class Flat : Apartment {
        public Flat(double square, int term, int count, int year, double wear) 
            : base(square, term, count, year, wear) { }

        public override double CalculateFee() {
            var sum = 0.0;

            if (Year > 2000) {
                sum = Square + ResidentsCount + (Square + ResidentsCount) * 0.2;
            } else {
                sum = Square + ResidentsCount * InsuranceTerm;
            }
            
            if (Wear > 0.2) {
                sum = sum - sum / 10;
            }

            return sum * 1.5;
        }
    }
}