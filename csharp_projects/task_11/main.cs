namespace task_11 {
    internal class main {
        static void Main(string[] args) {
            bool exception, repeat;
            int user_count = 100;
            string? input;
            Dictionary<string, string> users_n_votes = new Dictionary<string, string>();
            Random random = new Random();
            for (int i = 0; i < user_count; i++) users_n_votes.Add("user_" + i, (random.Next(2) + 1).ToString());
            do {
                repeat = false;
                do {
                    Console.WriteLine("Which techno DJ is better?");
                    Console.WriteLine("1. Amelie Lens");
                    Console.WriteLine("2. Charlotte de Witte");
                    Console.Write("Enter your username and vote: ");
                    input = Console.ReadLine();
                    exception = false;
                    try {
                        if (string.IsNullOrEmpty(input)) throw new Exception();
                        else {
                            string[] array_input = input.Split();
                            if (array_input.Length != 2 || (array_input[1] != "1" && array_input[1] != "2")) throw new Exception();
                            if (!users_n_votes.ContainsKey(array_input[0])) users_n_votes.Add(array_input[0], array_input[1]);
                            else users_n_votes[array_input[0]] = array_input[1];
                            do {
                                Console.Write("Do you want to enter a new vote (y/n): ");
                                input = Console.ReadLine();
                                exception = false;
                                try {
                                    if (string.IsNullOrEmpty(input)) throw new Exception();
                                    if (input == "y") repeat = true;
                                    else if (input == "n") {
                                        int vote_1, vote_2;
                                        vote_1 =  vote_2 = 0;
                                        foreach (string value in users_n_votes.Values) {
                                            if (value == "1") vote_1++;
                                            else if (value == "2") vote_2++;
                                        }
                                        Console.WriteLine("Amelie Lens has " + vote_1 + " votes: " + Math.Round(100 * vote_1 / (double)users_n_votes.Count, 2) + "%");
                                        Console.WriteLine("Charlotte de Witte has " + vote_2 + " votes: " + Math.Round(100 * vote_2 / (double)users_n_votes.Count, 2) + "%");
                                    }
                                    else throw new Exception();
                                } catch (Exception) {
                                    Console.WriteLine("Invalid Input");
                                    exception = true;
                                }
                            } while (exception);
                        }
                    } catch (Exception) {
                        Console.WriteLine("Invalid Input");
                        exception = true;
                    }
                } while (exception);
            } while (repeat);
        }
    } 
}