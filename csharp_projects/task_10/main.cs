using System.Text;
namespace task_10 {
    internal class main {
        static void Main(string[] args) {
            char[] consonant_uppercase = new char[] { 'B', 'C', 'D', 'F', 'G', 'Ğ', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'Ş', 'T', 'V', 'W', 'X', 'Y', 'Z' };
            char[] consonant_lowercase = new char[] { 'b', 'c', 'd', 'f', 'g', 'ğ', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 'ş', 't', 'v', 'w', 'x', 'y', 'z' };
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            bool exception, condition;
            string? input;
            do {
                Console.Write("Enter an input: ");
                input = Console.ReadLine();
                exception = false;
                if (string.IsNullOrEmpty(input)) exception = true;
                else {
                    foreach(string word in input.Split()) {
                        char[] array_characters = word.ToCharArray();
                        condition = false;
                        for (int i = 1; i < array_characters.Length; i++) if ((consonant_uppercase.Contains(array_characters[i - 1]) || consonant_lowercase.Contains(array_characters[i - 1])) && (consonant_uppercase.Contains(array_characters[i]) || consonant_lowercase.Contains(array_characters[i]))) condition = true;
                        if (condition) Console.Write("True ");
                        else Console.Write("False ");
                    }
                }
            } while (exception);
        }
    }
}