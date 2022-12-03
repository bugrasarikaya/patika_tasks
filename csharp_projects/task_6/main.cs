namespace task_6 {
    internal class main {
        static void Main(string[] args) {
            bool exception;
            int option_0, option_1;
            do {
                option_0 = select_shape();
                exception = false;
                switch (option_0) {
                    case 1:
                        circle.get_info();
                        option_1 = select_calculation();
                        switch (option_1) {
                            case 1:
                                Console.WriteLine("Perimeter: " + circle.calculate_perimeter());
                                break;
                            case 2:
                                Console.WriteLine("Area: " + circle.calculate_area());
                                break;
                        }
                        break;
                    case 2:
                        triangle.get_info();
                        option_1 = select_calculation();
                        switch (option_1) {
                            case 1:
                                Console.WriteLine("Perimeter: " + triangle.calculate_perimeter());
                                break;
                            case 2:
                                Console.WriteLine("Area: " + triangle.calculate_area());
                                break;
                        }
                        break;
                    case 3:
                        rectangle.get_info();
                        option_1 = select_calculation();
                        switch (option_1) {
                            case 1:
                                Console.WriteLine("Perimeter: " + rectangle.calculate_perimeter());
                                break;
                            case 2:
                                Console.WriteLine("Area: " + rectangle.calculate_area());
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        exception = true;
                        break;
                }
            } while (exception);
        }
        static int select_shape() {
            bool exception;
            int number;
            string? option;
            do {
                Console.WriteLine("1. Circle");
                Console.WriteLine("2. Triangle");
                Console.WriteLine("3. Rectangle");
                Console.Write("Enter an option: ");
                option = Console.ReadLine();
                exception = false;
                try {
                    if (string.IsNullOrEmpty(option)) throw new Exception();
                    else number = int.Parse(option);
                    if (number == 1 || number == 2 || number == 3) return number;
                    else throw new Exception();
                } catch (Exception) {
                    Console.WriteLine("Invalid Input");
                    exception = true;
                }
            } while (exception);
            return -1;
        }
        static int select_calculation() {
            bool exception;
            int number;
            string? option;
            do {
                Console.WriteLine("1. Perimeter");
                Console.WriteLine("2. Area");
                Console.Write("Enter an option: ");
                option = Console.ReadLine();
                exception = false;
                try {
                    if (string.IsNullOrEmpty(option)) throw new Exception();
                    else number = int.Parse(option);
                    if (number == 1 || number == 2) return number;
                    else throw new Exception();
                } catch (Exception) {
                    Console.WriteLine("Invalid Input");
                    exception = true;
                }
            } while (exception);
            return -1;
        }
    }
}