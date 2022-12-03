namespace task_6 {
    internal static class rectangle {
        static int edge_0, edge_1;
        internal static void get_info() {
            edge_0 = get_n_set_edge();
            edge_1 = get_n_set_edge();
        }
        static int get_n_set_edge() {
            bool exception;
            do {
                Console.Write("Enter an edge: ");
                string? input = Console.ReadLine();
                exception = false;
                try {
                    if (!string.IsNullOrEmpty(input)) return int.Parse(input);
                    else throw new Exception();
                } catch (Exception) {
                    Console.WriteLine("Invalid Input");
                    exception = true;
                }
            } while (exception);
            return -1;
        }
        internal static double calculate_perimeter() {
            return 2 * (edge_0 + edge_1);
        }
        internal static double calculate_area() {
            return edge_0 * edge_1;
        }
    }
}