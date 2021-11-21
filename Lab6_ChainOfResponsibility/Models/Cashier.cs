namespace Lab6_ChainOfResponsibility.Models {
    public class Cashier : Handler {
        public Cashier(Handler successor, Request request) : base(successor, request) { }

        public override void Handle(Request request) {
            if (CanHandle(request)) {
                Console.WriteLine($"Class Cashier handle request: {request.ToString()}");
            } else {
                base.Handle(request);
            }
        }
    }
}