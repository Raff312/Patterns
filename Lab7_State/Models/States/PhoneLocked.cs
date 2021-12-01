namespace Lab7_State.Models {
    partial class Phone {
        public class PhoneLocked : PhoneState {
            private static PhoneLocked? _instance;

            public override void Answer(Phone phone) {
                Console.WriteLine("PhoneLocked: Answer");
                ChangeState(phone, PhoneInConversation.GetInstance());
            }

            public override void Call(Phone phone) {
                Console.WriteLine("PhoneLocked: Call");
                Console.WriteLine("State dont changed");
            }

            public override void EndConversation(Phone phone) {
                Console.WriteLine("PhoneLocked: EndConversation");
                Console.WriteLine("State dont changed");
            }

            public override void TopUpBalance(Phone phone) {
                Console.WriteLine("PhoneLocked: TopUpBalance");
                ChangeState(phone, PhoneWait.GetInstance());
            }

            public static PhoneLocked GetInstance() {
                if (_instance == null) {
                    _instance = new PhoneLocked();
                }
                return _instance;
            }
        }
    }
}