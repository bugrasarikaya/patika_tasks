namespace task_7 {
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
                        List<int> list_number = new List<int>();
                        foreach (string element in input.Split()) list_number.Add(int.Parse(element));
                        int i;
                        for (i = 1; i < list_number.Count(); i += 2) {
                            if (list_number[i - 1] == list_number[i]) Console.Write(Math.Pow(list_number[i - 1] + list_number[i], 2) + " ");
                            else Console.Write(list_number[i - 1] + list_number[i] + " ");
                        }
                        if (list_number.Count() % 2 != 0) Console.Write(list_number[i - 1]);
                    }
                } catch (Exception) {
                    Console.WriteLine("Invalid Input");
                    exception = true;
                }
            } while (exception);
        }
    }
}