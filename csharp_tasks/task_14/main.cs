namespace task_14 {
    internal class main {
        static void Main(string[] args) {
            bool exception;
            int count, input_number, option;
            string? input;
            count = input_number = option = 0;
            do {
                Console.WriteLine("1. First Task");
                Console.WriteLine("2. Second Task");
                Console.WriteLine("3. Third Task");
                Console.WriteLine("4. Fourth Task");
                Console.WriteLine("5. Exit");
                do {
                    Console.Write("Enter your choice: ");
                    input = Console.ReadLine();
                    exception = false;
                        try {
                            if (input != null) option = Int32.Parse(input);
                            else throw new FormatException();
                        } catch (FormatException) {
                            Console.WriteLine("Invalid Input");
                            exception = true;
                        }
                } while (exception);
                switch (option) {
                    case 1: {
                            do {
                                Console.Write("Enter number count: ");
                                input = Console.ReadLine();
                                exception = false;
                                try {
                                    if (input != null) count = Int32.Parse(input);
                                    else throw new FormatException();
                                } catch (FormatException) {
                                    Console.WriteLine("Invalid Input");
                                    exception = true;
                                }
                            } while (exception);
                            List<int> list_number = new List<int>();
                            while (count != 0) {
                                do {
                                    Console.Write("Enter a number: ");
                                    input = Console.ReadLine();
                                    exception = false;
                                    try {
                                        if (input != null) input_number = Int32.Parse(input);
                                        else throw new FormatException();
                                    } catch (FormatException) {
                                        Console.WriteLine("Invalid Input");
                                        exception = true;
                                    }
                                } while (exception);
                                list_number.Add(input_number);
                                count--;
                            }
                            List<int> list_even_number = new List<int>();
                            foreach (int number in list_number) if (number % 2 == 0) list_even_number.Add(number);
                            if (list_even_number.Count != 0) {
                                Console.Write("Even Numbers: ");
                                foreach (int number in list_even_number) Console.Write(number + " ");
                            } else Console.Write("Could not find any even number.");
                            Console.WriteLine();
                        }
                        break;
                    case 2: {
                            List<int> list_number = new List<int>();
                            List<int> input_numbers = new List<int>();
                            do {
                                Console.Write("Enter two numbers: ");
                                input = Console.ReadLine();
                                exception = false;
                                if (input != null) {
                                    try {
                                        foreach (string number in input.Split()) input_numbers.Add(Int32.Parse(number));
                                        if (input_numbers.Count != 2) throw new FormatException();
                                    } catch (FormatException) {
                                        Console.WriteLine("Invalid Input");
                                        exception = true;
                                    }
                                } else {
                                    Console.WriteLine("Invalid Input");
                                    exception = true;
                                }
                            } while (exception);
                            for (int i = 0; i < input_numbers[0]; i++) {
                                do {
                                    Console.Write("Enter a number: ");
                                    input = Console.ReadLine();
                                    exception = false;
                                    try {
                                        if (input != null) list_number.Add(Int32.Parse(input));
                                        else throw new FormatException();
                                    } catch (FormatException) {
                                        Console.WriteLine("Invalid Input");
                                        exception = true;
                                    }
                                } while (exception);
                            }
                            List<int> result_numbers = new List<int>();
                            foreach (int number in list_number) if (number % 2 == 0 || number % input_numbers[1] == 0) result_numbers.Add(number);
                            if (result_numbers.Count != 0) {
                                Console.Write("Even or divisor numbers: ");
                                foreach (int number in result_numbers) Console.Write(number + " ");
                            } else Console.Write("Could not found any even or divisor number.");
                            Console.WriteLine();
                        }
                        break;
                    case 3: {
                            do {
                                Console.Write("Enter a number: ");
                                input = Console.ReadLine();
                                exception = false;
                                try {
                                    if (input != null) input_number = Int32.Parse(input);
                                    else throw new FormatException();
                                } catch (FormatException) {
                                    Console.WriteLine("Invalid Input");
                                    exception = true;
                                }
                            } while (exception);
                            List<string> list_word = new List<string>();
                            for (int i = 0; i < input_number; i++) {
                                do {
                                    Console.Write("Enter a word: ");
                                    input = Console.ReadLine();
                                    exception = false;
                                    if (input != null) list_word.Add(input.Trim());
                                    else {
                                        Console.WriteLine("Invalid Input");
                                        exception = true;
                                    }
                                } while (exception);
                            }
                            list_word.Sort();
                            list_word.Reverse();
                            foreach (string word in list_word) Console.Write(word + " ");
                            Console.WriteLine();
                        }
                        break;
                    case 4: {
                            int whitespace_count = 0;
                            string trimmed_text = "";
                            do {
                                Console.Write("Enter a text: ");
                                input = Console.ReadLine();
                                exception = false;
                                if (input != null) trimmed_text = input.Trim();
                                else {
                                    Console.WriteLine("Invalid Input");
                                    exception = true;
                                }
                            } while (exception);
                            for (int i = 0; i < trimmed_text.Length; i++) if (trimmed_text[i] == ' ') whitespace_count++;
                            Console.WriteLine("Word count: " + (whitespace_count + 1));
                            Console.WriteLine("Letter count: " + trimmed_text.Replace(" ", "").Length);
                        }
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while (option != 5);
        }
    }
}