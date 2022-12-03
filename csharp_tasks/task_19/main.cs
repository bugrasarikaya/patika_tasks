using System.Collections;
using System.Text;

namespace task_19 {
    internal class main {
        static void Main(string[] args) {
            bool exception;
            int number, option, count, total;
            number = option = 0;
            string? input;
            do {
                Console.WriteLine("1. Koleksiyonlar-Soru-1");
                Console.WriteLine("2. Koleksiyonlar-Soru-2");
                Console.WriteLine("3. Koleksiyonlar-Soru-3");
                Console.WriteLine("4. Exit");
                do {
                    Console.Write("Enter an option: ");
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
                            count = 20;
                            total = 0;
                            List<int> list_numbers = new List<int>();
                            do {
                                do {
                                    Console.Write("Enter a positive number: ");
                                    input = Console.ReadLine();
                                    exception = false;
                                    try {
                                        if (input != null) {
                                            number = Int32.Parse(input);
                                            if (number < 0) throw new FormatException();
                                        } else throw new FormatException();
                                    } catch (FormatException) {
                                        Console.WriteLine("Invalid Input");
                                        exception = true;
                                    }
                                } while (exception);
                                list_numbers.Add(number);
                            } while (--count > 0);
                            ArrayList arraylist_primes = new ArrayList();
                            ArrayList arraylist_non_primes = new ArrayList();
                            foreach (int element in list_numbers) {
                                if (check_prime(element)) arraylist_primes.Add(element);
                                else arraylist_non_primes.Add(element);
                            }
                            arraylist_primes.Sort();
                            arraylist_primes.Reverse();
                            arraylist_non_primes.Sort();
                            arraylist_non_primes.Reverse();
                            Console.WriteLine("Prime number count: " + arraylist_primes.Count);
                            foreach (int element in arraylist_primes) total += element;
                            Console.WriteLine("Prime number mean: " + total / arraylist_primes.Count);
                            Console.WriteLine("Non-prime number count: " + arraylist_primes.Count);
                            foreach (int element in arraylist_non_primes) total += element;
                            Console.WriteLine("Non-prime number mean: " + total / arraylist_non_primes.Count);
                        }
                        break;
                    case 2: {
                            int group_size, mean_bigger, mean_smaller;
                            count = 20;
                            group_size = 3;
                            total = 0;
                            int[] array_number = new int[count];
                            int[] array_bigger_group = new int[group_size];
                            int[] array_smaller_group = new int[group_size];
                            for (int i = 0; i < count; i++) {
                                do {
                                    Console.Write("Enter a number: ");
                                    input = Console.ReadLine();
                                    exception = false;
                                    try {
                                        if (input != null) number = Int32.Parse(input);
                                        else new FormatException();
                                    } catch (FormatException) {
                                        Console.WriteLine("Invalid Input");
                                        exception = true;
                                    }
                                } while (exception);
                                array_number[i] = number;
                            }
                            Array.Sort(array_number);
                            Array.Reverse(array_number);
                            for (int i = 0, j = count - 1; i < group_size && j > count - group_size - 1; i++, j--) {
                                array_bigger_group[i] = array_number[i];
                                array_smaller_group[i] = array_number[j];
                            }
                            foreach (int element in array_bigger_group) total += element;
                            mean_bigger = total / group_size;
                            total = 0;
                            foreach (int element in array_smaller_group) total += element;
                            mean_smaller = total / group_size;
                            Console.WriteLine("Bigger group mean: " + mean_bigger);
                            Console.WriteLine("Smaller group mean: " + mean_smaller);
                            Console.WriteLine("Total of means: " + (mean_bigger + mean_smaller));
                        }
                        break;
                    case 3: {
                            char[] vowels = { 'a', 'e', 'ı', 'i', 'o', 'ö', 'u', 'ü', 'A', 'E', 'I', 'İ', 'O', 'Ö', 'U', 'Ü' };
                            List<char> list_vowels = new List<char>();
                            Console.InputEncoding = Encoding.Unicode;
                            Console.OutputEncoding = Encoding.Unicode;
                            do {
                                Console.Write("Enter a text: ");
                                input = Console.ReadLine();
                                exception = false;
                                if(!string.IsNullOrEmpty(input)) {
                                    foreach (char letter in input) if (vowels.Contains(letter)) list_vowels.Add(letter);
                                    foreach (char element in list_vowels) Console.Write(element + " ");
                                    Console.WriteLine();
                                } else {
                                    Console.WriteLine("Invalid Input");
                                    exception = true;
                                }
                            } while (exception);
                        }
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while (option != 4);
        }
        static bool check_prime(int number) {
            if (number <= 1) return false;
            else if (number == 2) return true;
            else for (int i = 2; i < number / 2; i++) if (number % i == 0) return false;
            return true;
        }
    }
}