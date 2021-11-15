namespace Lab5_Facade.Utils {
    public static class Utils {
        public static T? GetValueFromUser<T>(string msg) {
            while (true) {
                Console.Write(msg);
                var userAnswer = Console.ReadLine();
                try {
                    return (T?)Convert.ChangeType(userAnswer, typeof(T));
                } catch (Exception) {
                    ConsoleTools.WriteLine(ConsoleColor.Red, "Invalid value type. Try again...");
                }
            }
        }
    }
}