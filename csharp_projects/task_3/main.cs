namespace task_3 {
    internal class main {
        static void Main(string[] args) {
            bool exception;
            do {
                Console.Write("Enter a radius: ");
                string? input = Console.ReadLine();
                exception = false;
                try {
                    if (string.IsNullOrEmpty(input)) throw new Exception();
                    else {
                        draw_filled_ellipse(int.Parse(input));
                    }
                } catch (Exception) {
                    Console.WriteLine("Invalid Input");
                    exception = true;
                }
            } while (exception);
        }
        static void draw_filled_circle(int r) {
            int h, k;
            h = r;
            k = -r;
            for (int y = 0; y >= -(2 * r); y--) {
                for (int x = 0; x <= (2 * r) * 2; x++) {
                    if (Math.Pow(x - h, 2) + Math.Pow(y - k, 2) <= Math.Pow(r, 2)) Console.Write("*"); // Filled circle formula.
                    else Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        static void draw_filled_ellipse(int r) {
            int a, b, h, k;
            a = 2 * r;
            b = r;
            h = a;
            k = -b;
            for (int y = 0; y >= -(2 * b); y--) {
                for (int x = 0; x <= (2 * a); x++) {
                    if (Math.Pow(x - h, 2) / Math.Pow(a, 2) + Math.Pow(y - k, 2) / Math.Pow(b, 2) <= 1) Console.Write("*"); // Filled ellipse formula.
                    else Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}