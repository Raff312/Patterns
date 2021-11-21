namespace Lab6_ChainOfResponsibility.Models {
    public class Manager : Handler {
        public Manager(Request request) : base(null, request) { }

        public override void Handle(Request request) {
            if (CanHandle(request)) {
                Console.WriteLine($"Class Manager handle request: {request.ToString()}");
            } else {
                base.Handle(request);
            }
        }
    }
}