namespace task_25 {
    internal class contact {
        string name;
        string surname;
        string phone_number;
        internal string property_name { get => name; set => name = value; }
        internal string property_surname { get => surname; set => surname = value; }
        internal string property_phone_number { get => phone_number; set => phone_number = value; }
        internal contact(string name, string surname, string phone_number) {
            this.name = name;
            this.surname = surname;
            this.phone_number = phone_number;
        }
    }
}