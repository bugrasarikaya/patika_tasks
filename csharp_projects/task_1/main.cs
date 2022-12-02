namespace task_1 {
    internal class main {
        static void Main(string[] args) {
            bool exception;
            do {
                Console.Write("Enter a depth: ");
                string? input = Console.ReadLine();
                exception = false;
                try {
                    if (string.IsNullOrEmpty(input)) throw new Exception();
                    else Console.WriteLine("Result: " + mean(int.Parse(input)));
                } catch (Exception) {
                    Console.WriteLine("Invalid Input");
                    exception = true;
                }
            } while (exception);
        }
        static int fibonacci(int depth) {
            return depth <= 1 ? depth : fibonacci(depth - 1) + fibonacci(depth - 2);
        }
        static double mean(int number) {
            double total = 0;
            for (int i = 1; i <= number; i++) total += fibonacci(i);
            return total / number;
        }
    }
}