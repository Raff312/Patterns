namespace Lab7_State.Models {
    partial class Phone {
        public abstract class PhoneState {
            public abstract void Call(Phone phone);
            public abstract void Answer(Phone phone);
            public abstract void EndConversation(Phone phone);
            public abstract void TopUpBalance(Phone phone);
            protected void ChangeState(Phone phone, PhoneState state) {
                phone.ChangeState(state);
            }
        }
    }
}