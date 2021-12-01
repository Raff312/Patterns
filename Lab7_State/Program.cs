using Lab7_State.Models;

namespace Lab7_State {
    public class Program {
        public static void Main() {
            var phone = new Phone();
            phone.Answer();
            phone.Answer();
            phone.EndConversation();
            phone.TopUpBalance();
            phone.Call();
        }
    }
}
