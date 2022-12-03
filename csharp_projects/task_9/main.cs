namespace task_9 {
    internal class main {
        static void Main(string[] args) {
            bool exception;
            string? input;
            do {
                Console.Write("Enter an input: ");
                input = Console.ReadLine();
                exception = false;
                try {
                    if (string.IsNullOrEmpty(input)) throw new Exception();
                    else {
                        foreach (string element in input.Split()) {
                            if (element.Length > 1) Console.Write(element.Substring(1, element.Length - 1) + element.Substring(0, 1) + " ");
                            else Console.Write(element + " ");
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