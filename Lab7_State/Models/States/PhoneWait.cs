namespace Lab7_State.Models {
    partial class Phone {
        public class PhoneWait : PhoneState {
            private static PhoneWait? _instance;

            public override void Answer(Phone phone) {
                Console.WriteLine("PhoneWait: Answer");
                ChangeState(phone, PhoneInConversation.GetInstance());
            }

            public override void Call(Phone phone) {
                Console.WriteLine("PhoneWait: Call");
                ChangeState(phone, PhoneInConversation.GetInstance());
            }

            public override void EndConversation(Phone phone) {
                Console.WriteLine("PhoneWait: EndConversation");
                Console.WriteLine("State dont changed");
            }

            public override void TopUpBalance(Phone phone) {
                Console.WriteLine("PhoneWait: TopUpBalance");
                Console.WriteLine("State dont changed");
            }

            public static PhoneWait GetInstance() {
                if (_instance == null) {
                    _instance = new PhoneWait();
                }
                return _instance;
            }
        }
    }
}