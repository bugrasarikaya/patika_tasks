namespace task_8 {
    internal class main {
        static void Main(string[] args) {
            Console.Write("Lütfen bir sayi giriniz: ");
            int sayi = int.Parse(Console.ReadLine());
            int sayac = 1;
            int toplam = 0;
            while (sayac <= sayi) {
                toplam += sayac;
                sayac++;
            }
            Console.WriteLine(toplam / sayi);
            char character = 'a';
            while (character < 'z') {
                Console.Write(character);
                character++;
            }
            string[] arabalar = { "BMV", "Ford", "Toyota", "Nissan" };
            foreach (var araba in arabalar) Console.WriteLine(araba);
        }
    }
}