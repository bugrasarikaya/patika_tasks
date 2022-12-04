namespace task_12 {
    internal class main {
        static void Main(string[] args) {
            bool exception;
            string? input;
            do {
                Console.Write("Enter your username: ");
                input = Console.ReadLine();
                exception = false;
                try {
                    if (string.IsNullOrEmpty(input) || !bank.check_user(input)) throw new Exception();
                    string username = input;
                    do {
                        Console.WriteLine("1. Withdraw");
                        Console.WriteLine("2. Deposit");
                        Console.WriteLine("3. Balance");
                        Console.WriteLine("4. Daily Log");
                        Console.WriteLine("5. Exit");
                        Console.Write("Enter your option: ");
                        input = Console.ReadLine();
                        switch (input) {
                            case "1":
                                bank.withdraw(username);
                                break;
                            case "2":
                                bank.deposit(username);
                                break;
                            case "3":
                                Console.WriteLine("Balance: " + bank.show_balance(username).ToString("N2"));
                                break;
                            case "4":
                                bank.show_daily_log();
                                break;
                            case "5":
                                break;
                            default:
                                Console.WriteLine("Invalid Input");
                                break;
                        }
                    } while (input != "5");
                } catch (Exception) {
                    Console.WriteLine("Invalid Input");
                    exception = true;
                }
            } while (exception);
        }
    }
}