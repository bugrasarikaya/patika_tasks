namespace task_8 {
    internal class main {
        static void Main(string[] args) {
            bool exception;
            int criterion_number = 68;
            string? input;
            do {
                Console.Write("Enter an input: ");
                input = Console.ReadLine();
                exception = false;
                try {
                    if (string.IsNullOrEmpty(input)) throw new Exception();
                    else {
                        int number, total_low, total_high;
                        total_low = total_high = 0;
                        foreach (string element in input.Split()) {
                            number = int.Parse(element);
                            if (number < criterion_number) total_low += criterion_number - number;
                            else if (number > criterion_number) total_high += (int)Math.Pow(criterion_number - number, 2);
                        }
                        Console.WriteLine(total_low + " " + total_high);
                    }
                } catch (Exception) {
                    Console.WriteLine("Invalid Input");
                    exception = true;
                }
            } while (exception);
        }
    }
}