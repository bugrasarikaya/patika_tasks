﻿namespace task_24 {
    internal class main {
        static void Main(string[] args) {
            Console.WriteLine(Gunler.Pazar);
            Console.WriteLine((int)Gunler.Cumartesi);
            int sıcaklık = 32;
            if (sıcaklık <= (int)HavaDurumu.Normal) Console.WriteLine("Dışarıya çıkmak için havanon biraz daha ısınmasını bekliyoruz.");
            else if (sıcaklık >= (int)HavaDurumu.Sıcak) Console.WriteLine("Dışarıya çıkmak için çok sıcak bir gün");
            else if (sıcaklık >= (int)HavaDurumu.Normal && sıcaklık < (int)HavaDurumu.CokSıcak) Console.WriteLine("Hadi dışarıya çıkalım!");
        }
    }
    enum Gunler {
        Pazartesi = 1,
        Salı,
        Çarşamba,
        Perşembe,
        Cuma = 23,
        Cumartesi,
        Pazar
    }
    enum HavaDurumu {
        Soguk = 5,
        Normal = 20,
        Sıcak = 25,
        CokSıcak = 30
    }
}