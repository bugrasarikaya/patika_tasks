namespace task_26 {
    internal class main {
        static void Main(string[] args) {
            bool exception;
            string? option;
            board board = new board();
            do {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :) ");
                Console.WriteLine("*******************************************");
                Console.WriteLine("(1) Board Listelemek");
                Console.WriteLine("(2) Board'a Kart Eklemek");
                Console.WriteLine("(3) Board'dan Kart Silmek");
                Console.WriteLine("(4) Kart Taşımak");
                Console.WriteLine("(5) Kart Güncellemek");
                Console.WriteLine("(6) Çıkış");
                Console.Write("Seçiminiz: ");
                option = Console.ReadLine();
                switch (option) {
                    case "1":
                        board.list();
                        break;
                    case "2": {
                            int person_id;
                            string? input_content, input_person_id, input_size, input_title;
                            do {
                                Console.Write("Başlık Giriniz: ");
                                input_title = Console.ReadLine();
                                exception = false;
                                try {
                                    if (string.IsNullOrEmpty(input_title)) throw new Exception();
                                    input_title = input_title.Trim();
                                    if (input_title.Length == 0) throw new Exception();
                                    do {
                                        Console.Write("İçerik Giriniz: ");
                                        input_content = Console.ReadLine();
                                        exception = false;
                                        try {
                                            if (string.IsNullOrEmpty(input_content)) throw new Exception();
                                            input_content = input_content.Trim();
                                            if (input_content.Length == 0) throw new Exception();
                                            do {
                                                Console.Write("Büyüklük Seçiniz -> XS(1), S(2), M(3), L(4), XL(5): ");
                                                input_size = Console.ReadLine();
                                                exception = false;
                                                try {
                                                    if (string.IsNullOrEmpty(input_size)) throw new Exception();
                                                    input_size = input_size.Trim();
                                                    if (input_size.Length == 0) throw new Exception();
                                                    if (input_size != "1" && input_size != "2" && input_size != "3" && input_size != "4" && input_size != "5") throw new Exception();
                                                    do {
                                                        Console.Write("Kişi Giriniz: ");
                                                        input_person_id = Console.ReadLine();
                                                        exception = false;
                                                        try {
                                                            if (string.IsNullOrEmpty(input_person_id)) throw new Exception();
                                                            input_person_id = input_person_id.Trim();
                                                            if (input_person_id.Length == 0) throw new Exception();
                                                            person_id = int.Parse(input_person_id);
                                                            if (board.check_person(person_id)) {
                                                                board.add_card(input_title, input_content, person_id, (enum_size)int.Parse(input_size));
                                                            } else throw new Exception();
                                                        } catch (Exception) {
                                                            Console.WriteLine("Invalid Input");
                                                            exception = true;
                                                        }
                                                    } while (exception);
                                                } catch (Exception) {
                                                    Console.WriteLine("Invalid Input");
                                                    exception = true;
                                                }
                                            } while (exception);
                                        } catch (Exception) {
                                            Console.WriteLine("Invalid Input");
                                            exception = true;
                                        }
                                    } while (exception);
                                } catch (Exception) {
                                    Console.WriteLine("Invalid Input");
                                    exception = true;
                                }
                            } while (exception);
                        }
                        break;
                    case "3": {
                            int[]? array_index;
                            bool repeat;
                            string? input_option, input_title;
                            do {
                                repeat = false;
                                do {
                                    Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
                                    Console.Write("Lütfen kart başlığını yazınız: ");
                                    input_title = Console.ReadLine();
                                    exception = false;
                                    try {
                                        if (string.IsNullOrEmpty(input_title)) throw new Exception();
                                        input_title = input_title.Trim();
                                        if (input_title.Length == 0) throw new Exception();
                                        array_index = board.search_card(input_title);
                                        if (array_index != null) board.delete_card(array_index);
                                        else {
                                            do {
                                                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                                                Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                                                Console.WriteLine("* Yeniden denemek için : (2)");
                                                Console.Write("Seçiminiz: ");
                                                input_option = Console.ReadLine();
                                                exception = false;
                                                try {
                                                    if (string.IsNullOrEmpty(input_option)) throw new Exception();
                                                    else if (input_option == "1") break;
                                                    else if (input_option == "2") repeat = true;
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
                        break;
                    case "4": {
                            bool repeat;
                            int[]? array_index;
                            string? input_line, input_option, input_person_id;
                            do {
                                repeat = false;
                                do {
                                    Console.Write("Taşımak istediğiniz kartın sahibini giriniz: ");
                                    input_person_id = Console.ReadLine();
                                    exception = false;
                                    try {
                                        if (string.IsNullOrEmpty(input_person_id)) throw new Exception();
                                        input_person_id = input_person_id.Trim();
                                        if (input_person_id.Length == 0) throw new Exception();
                                        array_index = board.search_card(int.Parse(input_person_id));
                                        if (array_index == null) {
                                            do {
                                                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                                                Console.WriteLine("* Taşımayı sonlandırmak için : (1)");
                                                Console.WriteLine("* Yeniden denemek için       : (2)");
                                                Console.Write("Seçiminiz: ");
                                                input_option = Console.ReadLine();
                                                exception = false;
                                                try {
                                                    if (string.IsNullOrEmpty(input_option)) throw new Exception();
                                                    else if (input_option == "1") break;
                                                    else if (input_option == "2") repeat = true;
                                                    else throw new Exception();
                                                } catch (Exception) {
                                                    Console.WriteLine("Invalid Input");
                                                    exception = true;
                                                }
                                            } while (exception);
                                        } else {
                                            do {
                                                Console.Write("Taşımak istediğiniz kolonu giriniz -> TODO(0), IN PROGRESS(1), DONE(2): ");
                                                input_line = Console.ReadLine();
                                                exception = false;
                                                try {
                                                    if (string.IsNullOrEmpty(input_line)) throw new Exception();
                                                    if (input_line == "0" || input_line == "1" || input_line == "2") board.move_card(array_index, int.Parse(input_line));
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
                        break;
                    case "5": {
                            int person_id;
                            int[]? array_index;
                            string? input_content, input_person_id, input_size, input_title;
                            do {
                                Console.Write("Kişi Giriniz: ");
                                input_person_id = Console.ReadLine();
                                exception = false;
                                try {
                                    if (string.IsNullOrEmpty(input_person_id)) throw new Exception();
                                    input_person_id = input_person_id.Trim();
                                    if (input_person_id.Length == 0) throw new Exception();
                                    person_id = int.Parse(input_person_id);
                                    array_index = board.search_card(person_id);
                                    if (array_index != null) {
                                        do {
                                            Console.Write("Başlık Giriniz: ");
                                            input_title = Console.ReadLine();
                                            exception = false;
                                            try {
                                                if (string.IsNullOrEmpty(input_title)) throw new Exception();
                                                input_title = input_title.Trim();
                                                if (input_title.Length == 0) throw new Exception();
                                                do {
                                                    Console.Write("İçerik Griniz: ");
                                                    input_content = Console.ReadLine();
                                                    exception = false;
                                                    try {
                                                        if (string.IsNullOrEmpty(input_content)) throw new Exception();
                                                        input_content = input_content.Trim();
                                                        if (input_content.Length == 0) throw new Exception();
                                                        do {
                                                            Console.Write("Büyüklük Seçiniz -> XS(1), S(2), M(3), L(4), XL(5): ");
                                                            input_size = Console.ReadLine();
                                                            exception = false;
                                                            try {
                                                                if (string.IsNullOrEmpty(input_size)) throw new Exception();
                                                                input_size = input_size.Trim();
                                                                if (input_size.Length == 0) throw new Exception();
                                                                if (input_size != "1" && input_size != "2" && input_size != "3" && input_size != "4" && input_size != "5") throw new Exception();
                                                                board.update_card(array_index, input_title, input_content, (enum_size)int.Parse(input_size));
                                                            } catch (Exception) {
                                                                Console.WriteLine("Invalid Input");
                                                                exception = true;
                                                            }
                                                        } while (exception);
                                                    } catch (Exception) {
                                                        Console.WriteLine("Invalid Input");
                                                        exception = true;
                                                    }
                                                } while (exception);
                                            } catch (Exception) {
                                                Console.WriteLine("Invalid Input");
                                                exception = true;
                                            }
                                        } while (exception);
                                    } else throw new Exception();
                                } catch (Exception) {
                                    Console.WriteLine("Invalid Input");
                                    exception = true;
                                }
                            } while (exception);
                        }
                        break;
                    case "6":
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while (option != "6");
        }
    }
}