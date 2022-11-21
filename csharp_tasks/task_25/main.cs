namespace task_25 {
    internal class main {
        static void Main(string[] args) {
            bool exception;
            string? option;
            phonebook phonebook_object = new phonebook();
            do {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
                Console.WriteLine("*******************************************");
                Console.WriteLine("(1) Yeni Numara Kaydetmek");
                Console.WriteLine("(2) Varolan Numarayı Silmek");
                Console.WriteLine("(3) Varolan Numarayı Güncelleme");
                Console.WriteLine("(4) Rehberi Listelemek");
                Console.WriteLine("(5) Rehberde Arama Yapmak﻿");
                Console.WriteLine("(6) Çıkış﻿");
                option = Console.ReadLine();
                switch (option) {
                    case "1": {
                            string? input_name, input_surname, input_phone_number;
                            do {
                                Console.Write("Lütfen isim giriniz: ");
                                input_name = Console.ReadLine();
                                exception = false;
                                if (input_name != null) input_name = input_name.Trim();
                                else {
                                    Console.WriteLine("Invalid Input");
                                    exception = true;
                                }
                            } while (exception);
                            do {
                                Console.Write("Lütfen soyisim giriniz: ");
                                input_surname = Console.ReadLine();
                                exception = false;
                                if (input_surname != null) input_surname = input_surname.Trim();
                                else {
                                    Console.WriteLine("Invalid Input");
                                    exception = true;
                                }
                            } while (exception);
                            do {
                                Console.Write("Lütfen telefon numarası giriniz: ");
                                input_phone_number = Console.ReadLine();
                                exception = false;
                                if (input_phone_number != null) input_phone_number = input_phone_number.Trim();
                                else {
                                    Console.WriteLine("Invalid Input");
                                    exception = true;
                                }
                            } while (exception);
                            if (input_name != null && input_surname != null && input_phone_number != null) phonebook_object.add_contact(input_name, input_surname, input_phone_number);
                        }
                        break;
                    case "2": {
                            bool repeat;
                            string? input_option, input_name, input_surname;
                            do {
                                repeat = false;
                                do {
                                    Console.Write("Lütfen numarasını silmek istediğiniz kişinin adını giriniz: ");
                                    input_name = Console.ReadLine();
                                    exception = false;
                                    if (input_name != null) input_name = input_name.Trim();
                                    else {
                                        Console.WriteLine("Invalid Input");
                                        exception = true;
                                    }
                                } while (exception);
                                do {
                                    Console.Write("Lütfen numarasını silmek istediğiniz kişinin soyadını giriniz: ");
                                    input_surname = Console.ReadLine();
                                    exception = false;
                                    if (input_surname != null) input_surname = input_surname.Trim();
                                    else {
                                        Console.WriteLine("Invalid Input");
                                        exception = true;
                                    }
                                } while (exception);
                                if (input_name != null && input_surname != null) {
                                    int index = phonebook_object.search_contact(input_name, input_surname);
                                    if (index >= 0) {
                                        do {
                                            Console.Write(input_name + " " + input_surname + " isimli kişi rehberden silinmek üzere, onaylıyor musunuz (y/n): ");
                                            input_option = Console.ReadLine();
                                            exception = false;
                                            if (input_option == "y") phonebook_object.delete_contact(index);
                                            else if (input_option == "n") {
                                                do {
                                                    Console.WriteLine("Lütfen bir seçim yapınız.");
                                                    Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                                                    Console.WriteLine("* Yeniden denemek için      : (2)");
                                                    input_option = Console.ReadLine();
                                                    exception = false;
                                                    if (input_option == "1") break;
                                                    else if (input_option == "2") repeat = true;
                                                    else {
                                                        Console.WriteLine("Invalid Input");
                                                        exception = true;
                                                    }
                                                } while (exception);

                                            } else {
                                                Console.WriteLine("Invalid Input");
                                                exception = true;
                                            }
                                        } while (exception);
                                    } else {
                                        do {
                                            Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                                            Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                                            Console.WriteLine("* Yeniden denemek için      : (2)");
                                            input_option = Console.ReadLine();
                                            exception = false;
                                            if (input_option == "1") break;
                                            else if (input_option == "2") repeat = true;
                                            else {
                                                Console.WriteLine("Invalid Input");
                                                exception = true;
                                            }
                                        } while (exception);
                                    }
                                }
                            } while (repeat);
                        }
                        break;
                    case "3": {
                            bool repeat;
                            int index;
                            string? input_option, input_name, input_phone_number, input_surname;
                            do {
                                repeat = false;
                                do {
                                    Console.Write("Lütfen numarasını değiştirmek istediğiniz kişinin adını giriniz: ");
                                    input_name = Console.ReadLine();
                                    exception = false;
                                    if (input_name != null) input_name = input_name.Trim();
                                    else {
                                        Console.WriteLine("Invalid Input");
                                        exception = true;
                                    }
                                } while (exception);
                                do {
                                    Console.Write("Lütfen numarasını değiştirmek istediğiniz kişinin soyadını giriniz: ");
                                    input_surname = Console.ReadLine();
                                    exception = false;
                                    if (input_surname != null) input_surname = input_surname.Trim();
                                    else {
                                        Console.WriteLine("Invalid Input");
                                        exception = true;
                                    }
                                } while (exception);
                                if (input_name != null && input_surname != null) {
                                    index = phonebook_object.search_contact(input_name, input_surname);
                                    if (index >= 0) {
                                        do {
                                            Console.Write("Lütfen yeni bir numarası giriniz: ");
                                            input_phone_number = Console.ReadLine();
                                            exception = false;
                                            if (input_phone_number != null) input_phone_number = input_phone_number.Trim();
                                            else {
                                                Console.WriteLine("Invalid Input");
                                                exception = true;
                                            }
                                        } while (exception);
                                        do {
                                            Console.Write(input_name + " " + input_surname + " isimli kişinin numarası değişmek üzere, onaylıyor musunuz (y/n): ");
                                            input_option = Console.ReadLine();
                                            exception = false;
                                            if (input_option == "y") {
                                                if (input_phone_number != null) phonebook_object.update_contact(index, input_phone_number);
                                            } else if (input_option == "n") {
                                                do {
                                                    Console.WriteLine("Lütfen bir seçim yapınız.");
                                                    Console.WriteLine("* Değiştirmeyi sonlandırmak için : (1)");
                                                    Console.WriteLine("* Yeniden denemek için           : (2)");
                                                    input_option = Console.ReadLine();
                                                    exception = false;
                                                    if (input_option == "1") break;
                                                    else if (input_option == "2") repeat = true;
                                                    else {
                                                        Console.WriteLine("Invalid Input");
                                                        exception = true;
                                                    }
                                                } while (exception);

                                            } else {
                                                Console.WriteLine("Invalid Input");
                                                exception = true;
                                            }
                                        } while (exception);
                                    } else {
                                        do {
                                            Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                                            Console.WriteLine("* Değiştirmeyi sonlandırmak için : (1)");
                                            Console.WriteLine("* Yeniden denemek için           : (2)");
                                            input_option = Console.ReadLine();
                                            exception = false;
                                            if (input_option == "1") break;
                                            else if (input_option == "2") repeat = true;
                                            else {
                                                Console.WriteLine("Invalid Input");
                                                exception = true;
                                            }
                                        } while (exception);
                                    }
                                }
                            } while (repeat);
                        }
                        break;
                    case "4":
                        phonebook_object.list_contacts();
                        break;
                    case "5": {
                            bool repeat;
                            int index;
                            string? input_option, input_name, input_phone_number, input_surname;
                            do {
                                repeat = false;
                                do {
                                    Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
                                    Console.WriteLine("**********************************************");
                                    Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
                                    Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)");
                                    input_option = Console.ReadLine();
                                    exception = false;
                                    if (input_option == "1") {
                                        do {
                                            Console.WriteLine("Lütfen aramak istediğiniz kişinin adını giriniz: ");
                                            input_name = Console.ReadLine();
                                            exception = false;
                                            if (input_name != null) input_name = input_name.Trim();
                                            else {
                                                Console.WriteLine("Invalid Input");
                                                exception = true;
                                            }
                                        } while (exception);
                                        do {
                                            Console.WriteLine("Lütfen aramak istediğiniz kişinin soyadını giriniz: ");
                                            input_surname = Console.ReadLine();
                                            exception = false;
                                            if (input_surname != null) input_surname = input_surname.Trim();
                                            else {
                                                Console.WriteLine("Invalid Input");
                                                exception = true;
                                            }
                                        } while (exception);
                                        if (input_name != null && input_surname != null) {
                                            index = phonebook_object.search_contact(input_name, input_surname);
                                            if (index >= 0) phonebook_object.show_contact(index);
                                            else {
                                                do {
                                                    Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                                                    Console.WriteLine("* Aramayı sonlandırmak için : (1)");
                                                    Console.WriteLine("* Yeniden denemek için      : (2)");
                                                    input_option = Console.ReadLine();
                                                    exception = false;
                                                    if (input_option == "1") break;
                                                    else if (input_option == "2") repeat = true;
                                                    else {
                                                        Console.WriteLine("Invalid Input");
                                                        exception = true;
                                                    }
                                                } while (exception);
                                            }
                                        }
                                    } else if (input_option == "2") {
                                        do {
                                            Console.WriteLine("Lütfen aramak istediğiniz kişinin numarasını giriniz: ");
                                            input_phone_number = Console.ReadLine();
                                            exception = false;
                                            if (input_phone_number != null) input_phone_number = input_phone_number.Trim();
                                            else {
                                                Console.WriteLine("Invalid Input");
                                                exception = true;
                                            }
                                        } while (exception);
                                        if (input_phone_number != null) {
                                            index = phonebook_object.search_contact(input_phone_number);
                                            if (index >= 0) phonebook_object.show_contact(index);
                                            else {
                                                do {
                                                    Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                                                    Console.WriteLine("* Aramayı sonlandırmak için : (1)");
                                                    Console.WriteLine("* Yeniden denemek için      : (2)");
                                                    input_option = Console.ReadLine();
                                                    exception = false;
                                                    if (input_option == "1") break;
                                                    else if (input_option == "2") repeat = true;
                                                    else {
                                                        Console.WriteLine("Invalid Input");
                                                        exception = true;
                                                    }
                                                } while (exception);
                                            }
                                        }
                                    } else {
                                        Console.WriteLine("Invalid Input");
                                        exception = true;
                                    }
                                } while (exception);
                            } while (repeat);
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