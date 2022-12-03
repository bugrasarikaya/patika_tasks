namespace task_6 {
    internal static class triangle {
        static int edge_0, edge_1, edge_2;
        internal static void get_info() {
            edge_0 = get_n_set_edge();
            edge_1 = get_n_set_edge();
            edge_2 = get_n_set_edge();
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
            return edge_0 + edge_1 + edge_2;
        }
        internal static double calculate_area() {
            int u = (edge_0 + edge_1 + edge_2) / 2;
            return Math.Sqrt(u * (u - edge_0) * (u - edge_1) * (u - edge_2));
        }
    }
}