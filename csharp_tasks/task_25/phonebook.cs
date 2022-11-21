namespace task_25 {
    internal class phonebook {
        List<contact> list_contact;
        internal phonebook() {
            list_contact = new List<contact> {
                new contact("Deckard", "Cain", "6666666666"),
                new contact("Larry", "Laffer", "2096836858"),
                new contact("Mona", "Sax", "5455550122"),
                new contact("Patrick ", "Bateman", "2125556342"),
                new contact("Janine", "Melnitz", "8005552368")
            };
        }
        internal void add_contact(string name, string surname, string phone_number) {
            list_contact.Add(new contact(name, surname, phone_number));
        }
        internal void delete_contact(int index) {
            list_contact.RemoveAt(index);
        }
        internal void update_contact(int index, string phone_number) {
            list_contact[index].property_phone_number = phone_number;
        }
        internal void list_contacts() {
            Console.WriteLine("Telefon Rehberi");
            Console.WriteLine("**********************************************");
            foreach (contact contact_object in list_contact) {
                Console.WriteLine("İsim: " + contact_object.property_name);
                Console.WriteLine("Soyisim: " + contact_object.property_surname);
                Console.WriteLine("Telefon Numarası: " + contact_object.property_phone_number);
                Console.WriteLine("-");
            }
        }
        internal int search_contact(string name, string surname) {
            return list_contact.FindIndex(contact => contact.property_name == name && contact.property_surname == surname);
        }
        internal int search_contact(string phone_number) {
            return list_contact.FindIndex(contact => contact.property_phone_number == phone_number);
        }
        internal void show_contact(int index) {
            Console.WriteLine("Arama Sonuçlarınız:");
            Console.WriteLine("**********************************************");
            Console.WriteLine("İsim: " + list_contact[index].property_name);
            Console.WriteLine("Soyisim: " + list_contact[index].property_surname);
            Console.WriteLine("Telefon Numarası: " + list_contact[index].property_phone_number);
        }
    }
}