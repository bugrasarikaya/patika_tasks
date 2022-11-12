namespace task_10 {
    internal class main {
        static void Main(string[] args) {
            int[] sayiDizisi = { 23, 12, 4, 86, 72, 3, 11, 17 };
            foreach (var sayi in sayiDizisi) Console.WriteLine(sayi);
            Array.Sort(sayiDizisi);
            foreach (var sayi in sayiDizisi) Console.WriteLine(sayi);
            Array.Clear(sayiDizisi, 2, 2);
            foreach (var sayi in sayiDizisi) Console.WriteLine(sayi);
            Array.Reverse(sayiDizisi);
            foreach (var sayi in sayiDizisi) Console.WriteLine(sayi);
            Console.WriteLine(Array.IndexOf(sayiDizisi, 23));
            Array.Resize<int>(ref sayiDizisi, 9);
            sayiDizisi[8] = 99;
            foreach (var sayi in sayiDizisi) Console.WriteLine(sayi);
        }
    }
}