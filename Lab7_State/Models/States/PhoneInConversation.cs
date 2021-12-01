namespace Lab7_State.Models {
    partial class Phone {
        public class PhoneInConversation : PhoneState {
            private static PhoneInConversation? _instance;

            public override void Answer(Phone phone) {
                Console.WriteLine("PhoneInConversation: Answer");
                Console.WriteLine("State dont changed");
            }

            public override void Call(Phone phone) {
                Console.WriteLine("PhoneInConversation: Call");
                Console.WriteLine("State dont changed");
            }

            public override void EndConversation(Phone phone) {
                Console.WriteLine("PhoneInConversation: EndConversation");
                ChangeState(phone, PhoneLocked.GetInstance());
            }

            public override void TopUpBalance(Phone phone) {
                Console.WriteLine("PhoneInConversation: TopUpBalance");
                Console.WriteLine("State dont changed");
            }

            public static PhoneInConversation GetInstance() {
                if (_instance == null) {
                    _instance = new PhoneInConversation();
                }
                return _instance;
            }
        }
    }
}