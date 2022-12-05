using System.Globalization;

namespace task_12 {
    internal static class bank {
        static int user_count = 10;
        static Dictionary<string, double> bank_storage;
        static bank() {
            bank_storage = new Dictionary<string, double>();
            Random random = new Random();
            for (int i = 0; i < user_count; i++) bank_storage.Add("user_" + i, random.Next(10001));
            log("Deposited cash amounts were randomized.");
        }
        internal static bool check_user(string username) {
            bool result = bank_storage.ContainsKey(username);
            if(result) log(username + " accessed system.");
            else log(username + " could not access system because of unkown username.");
            return result;
        }
        internal static void withdraw(string username) {
            bool exception;
            string? input;
            do {
                Console.Write("Enter an amount: ");
                input = Console.ReadLine();
                exception = false;
                try {
                    if (string.IsNullOrEmpty(input)) throw new Exception();
                    double amount = double.Parse(input);
                    bank_storage[username] -= amount;
                    log(username + " withdraw " + amount.ToString("N2") + " cash.");
                } catch (Exception) {
                    Console.WriteLine("Invalid Input");
                    log(username + " entered an invalid input.");
                    exception = true;
                }
            } while (exception);
        }
        internal static void deposit(string username) {
            bool exception;
            string? input;
            do {
                Console.Write("Enter an amount: ");
                input = Console.ReadLine();
                exception = false;
                try {
                    if (string.IsNullOrEmpty(input)) throw new Exception();
                    double amount = double.Parse(input);
                    bank_storage[username] += amount;
                    log(username + " deposit " + amount.ToString("N2") + " cash.");
                } catch (Exception) {
                    log(username + " entered an invalid input.");
                    Console.WriteLine("Invalid Input");
                    exception = true;
                }
            } while (exception);
        }
        internal static double show_balance(string username) {
            log(username + " queried its balance.");
            return bank_storage[username];
        }
        static void log(string log_text) {
            DateTime now = DateTime.Now;
            string filename = @"..\..\..\log_" + now.ToString("ddMMyyyy") + ".txt";
            File.AppendAllText(filename, now + " - " + log_text + "\n");
        }
        internal static void show_daily_log() {
            DateTime now = DateTime.Now;
            string filename = @"..\..\..\log_" + now.ToString("ddMMyyyy") + ".txt";
            Console.Write(File.ReadAllText(filename));
        }
    }
}
