namespace Lab7_State.Models {
    partial class Phone {
        private PhoneState _state;

        public Phone() {
            _state = new PhoneWait();
        }

        public void Call() {
            _state.Call(this);
        }

        public void Answer() {
            _state.Answer(this);
        }

        public void EndConversation() {
            _state.EndConversation(this);
        }

        public void TopUpBalance() {
            _state.TopUpBalance(this);
        }

        private void ChangeState(PhoneState state) {
            _state = state;
        }
    }
}