namespace task_5 {
    internal class main {
        static void Main(string[] args) {
            Console.Write("Enter an input: ");
            string? input = Console.ReadLine();
            if(!string.IsNullOrEmpty(input)){
                foreach (string element in input.Split()) {
                    Console.Write(element.Substring(1, element.Length - 1) + element.Substring(0, 1) + " ");
                }
            }
        }
    }
}