namespace task_6 {
     internal static class circle {
        static int radius;
        internal static void get_info() {
            bool exception;
            do {
                Console.Write("Enter a radius: ");
                string? input = Console.ReadLine();
                exception = false;
                try {
                    if (!string.IsNullOrEmpty(input)) radius = int.Parse(input);
                    else throw new Exception();
                } catch (Exception) {
                    Console.WriteLine("Invalid Input");
                    exception = true;
                }
            } while (exception);
        }
        internal static double calculate_perimeter() {
            return 2 * 3.14 * radius;
        }
        internal static double calculate_area() {
            return 3.14 * Math.Pow(radius, 2);
        }
    }
}