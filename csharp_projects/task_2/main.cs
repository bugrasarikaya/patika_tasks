namespace task_2 {
    internal class main {
        static void Main(string[] args) {
            bool exception;
            do {
                Console.Write("Enter a height: ");
                string? input = Console.ReadLine();
                exception = false;
                try {
                    if (string.IsNullOrEmpty(input)) throw new Exception();
                    draw_triangle(int.Parse(input));
                } catch (Exception) {
                    Console.WriteLine("Invalid Input");
                    exception = true;
                }
            } while (exception);
        }
        static void draw_triangle(int height) {
            int width = 1;
            while(height-- > 0) {
                for (int i = 0; i < width; i++) Console.Write("*");
                width++;
                Console.WriteLine();
            }
        }
    }
}