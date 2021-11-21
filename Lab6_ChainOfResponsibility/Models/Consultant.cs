namespace Lab6_ChainOfResponsibility.Models {
    public class Consultant : Handler {
        public Consultant(Handler successor, Request request) : base(successor, request) { }

        public override void Handle(Request request) {
            if (CanHandle(request)) {
                Console.WriteLine($"Class Consultant handle request: {request.ToString()}");
            } else {
                base.Handle(request);
            }
        }
    }
}