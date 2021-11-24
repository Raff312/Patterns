namespace Lab6_ChainOfResponsibility.Models {
    public abstract class Handler {
        private Handler? _sucessor;
        private Request _request;

        public Handler(Handler? successor, Request request) {
            _sucessor = successor;
            _request = request;
        }

        public virtual void Handle(Request request) {
            if (_sucessor != null) {
                _sucessor.Handle(request);
            } else {
                Console.WriteLine("This request can't be handled");
            }
        }

        protected virtual bool CanHandle(Request request) {
            return _request == request;
        }
    }
}