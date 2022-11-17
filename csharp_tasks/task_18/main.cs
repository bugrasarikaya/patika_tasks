using System.Collections;

namespace task_18 {
    internal class main {
        static void Main(string[] args) {
            ArrayList liste_1 = new ArrayList();
            liste_1.Add("Ayşe");
            liste_1.Add(2);
            liste_1.Add(true);
            liste_1.Add('A');
            Console.WriteLine(liste_1[1]);
            foreach (var item in liste_1) Console.WriteLine(item);
            string[] renkler = { "kırmızı", "sarı", "yesil" };
            List<int> sayılar = new List<int>() { 1, 8, 3, 7, 9, 92, 5 };
            ArrayList liste_2 = new ArrayList();
            ArrayList liste_3 = new ArrayList();
            liste_2.AddRange(renkler);
            liste_3.AddRange(sayılar);
            foreach (var item in liste_2) Console.WriteLine(item);
            foreach (var item in liste_3) Console.WriteLine(item);
            liste_3.Sort();
            foreach (var item in liste_3) Console.WriteLine(item);
            Console.WriteLine(liste_3.BinarySearch(9));
            liste_3.Reverse();
            foreach (var item in liste_3) Console.WriteLine(item);
            liste_3.Clear();
            foreach (var item in liste_3) Console.WriteLine(item);
        }
    }
}