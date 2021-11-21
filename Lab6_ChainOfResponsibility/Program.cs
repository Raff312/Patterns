using Lab6_ChainOfResponsibility.Models;

namespace Lab6_ChainOfResponsibility {
    public class Program {
        public static void Main() {
            var manager = new Manager(Request.PROBLEM);
            var consultant = new Consultant(manager, Request.CREDIT);
            var cashier = new Cashier(consultant, Request.PAYMENT);

            cashier.Handle(Request.PROBLEM);
        }
    }
}
