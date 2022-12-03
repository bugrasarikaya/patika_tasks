namespace task_4 {
    internal class main {
        static void Main(string[] args) {
            bool exception;
            do {
                Console.Write("Enter an input: ");
                string? input = Console.ReadLine();
                exception = false;
                try {
                    if (!string.IsNullOrEmpty(input)) {
                        foreach (string element in input.Split()) {
                            string[] array_input = element.Split(',');
                            if (int.Parse(array_input[1]) > array_input[0].Length) Console.Write(array_input[0] + " ");
                            else Console.Write(array_input[0].Remove(int.Parse(array_input[1]), 1) + " ");
                        }
                    }
                } catch (Exception) {
                    Console.WriteLine("Invalid Input");
                    exception = true;
                }
            } while (exception);
        }
    }
}