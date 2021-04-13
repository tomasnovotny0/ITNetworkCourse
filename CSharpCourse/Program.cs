using System;
using System.Linq;

namespace CSharpCourse {
    class Program {
        static void Main(string[] args) {
            int[] pole = new int[10];
            for (int i = 0; i < pole.Length; i++) {
                pole[i] = i + 1;
            }

            foreach (int i in pole) {
                Console.Write("{0} ", i);
            }

            Console.WriteLine();

            // seznam užitečných metod
            // Min, Max, Average, Sum
            // Concat, Intersect, Union
            // First, Last
            // Take, Skip
            // Contains
            // Reverse
            // Distinct

            int[] cisla = {1, 2, 3, 3, 3, 5};
            cisla = cisla.Distinct().ToArray();

            Console.WriteLine("Ahoj, spočítám průměr ze zadaných čísel.\nKolik čísel zadáš?");
            int pocet;
            while (!int.TryParse(Console.ReadLine(), out pocet)) {
                Console.WriteLine("Neplatné číslo");
            }
            int[] seznamCisel = new int[pocet];
            for (int i = 0; i < pocet; i++) {
                Console.Write("Zadej {0}. číslo: ", i + 1);
                int cislo;
                while (!int.TryParse(Console.ReadLine(), out cislo)) {
                    Console.WriteLine("Neplatné číslo!");
                }
                seznamCisel[i] = cislo;
            }

            Console.WriteLine("Průměr zadaných čísel je: {0}", seznamCisel.Average());
        }

        /*
         * Vytvořte program, který naplní pole o deseti prvcích postupně čísly od 10 do 1. Pole následně vypište pomocí cyklu foreach.
         */
        static void Cviceni1() {
            int[] pole = new int[10];
            for (int i = 0; i < 10; i++) {
                pole[9 - i] = i + 1;
            }
            foreach (int i in pole) {
                Console.WriteLine(i);
            }
        }

        /*
         * Vytvořte program, kterému zadáte slovo a on zjistí, zda je to název ovoce nebo zeleniny.
         * Pokud tedy zadáme např. "malina", vypíše, že se jedná o ovoce. Pokud "brokolice", vypíše, že se jedná o zeleninu.
         * Na velikosti písmen nezáleží. Program samozřejmě rozpozná několik slov a pokud narazí na slovo, které není definované,
         * tak na tuto skutečnost uživatele upozorní. Vyhněte se použití složitého větvení a místo toho použijte pole.
         * Program se stále opakuje v cyklu dokud ho neukončíme.
         * Před ukončení program vypíše na kolik slov jsme se ho zeptali. Pro lepší pochopení je vše názorně ukázáno na obrázku níže.
         * Program naučte rozeznávat alespoň tyto plodiny:
         * 
         *     Zeleninu: zelí, okurka, rajče, paprika, ředkev, mrkev, brokolice
         *     Ovoce: jablko, hruška, pomeranč, jahoda, banán, kiwi, malina
         */
        static void Cviceni2() {
            string[] zelenina = {"zelí", "okurka", "rajče", "paprika", "ředkev", "mrkev", "brokolice"};
            string[] ovoce = {"jablko", "hruška", "pomeranč", "jahoda", "banán", "kiwi", "malina"};
            bool pokracovat = true;
            int pocetDotazu = 0;
            while (pokracovat) {
                Console.WriteLine("Zadej název libovolného ovoce nebo zeleniny:");
                string polozka = Console.ReadLine();
                if (ovoce.Contains(polozka.ToLower())) {
                    Console.WriteLine("Zadal jsi ovoce");
                } else if (zelenina.Contains(polozka.ToLower())) {
                    Console.WriteLine("Zadal jsi zeleninu");
                }
                else {
                    Console.WriteLine("Tvoje slovo nemám v seznamu");
                }

                Console.WriteLine("Přeješ si zadat další slovo? (ano/ne)");
                if (!Console.ReadLine().ToLower().Equals("ano")) {
                    pokracovat = false;
                }

                ++pocetDotazu;
            }

            Console.WriteLine("Zadal jsi {0} slov", pocetDotazu);
        }

        /*
         * Vytvořte program, který si nechá na vstupu zadat několik čísel (jejich počet si zvolí uživatel) a z těchto čísel následně vypočítá medián.
         * Pro každé zadané číslo vypíše jeho odchylku od tohoto mediánu.
         * U mediánu zanedbejte fakt, že se při sudém počtu prvků průměruje z prostředních dvou, k jeho určení
         * tedy pouze sáhněte na prostřední index, získaný jako délka / 2;
         */
        static void Cviceni3() {
            Console.WriteLine("Zadej počet čísel: ");
            int pocet = int.Parse(Console.ReadLine());
            int[] cisla = new int[pocet];
            for (int i = 0; i < pocet; i++)
            {
                Console.Write("Zadej {0}. číslo: ", i + 1);
                cisla[i] = int.Parse(Console.ReadLine());
            }
            int[] cisla2 = new int[cisla.Length];
            for (int i = 0; i < cisla.Length; i++)
            {
                cisla2[i] = cisla[i];
            }
            Array.Sort(cisla2);
            float median = cisla2[cisla2.Length / 2];
            foreach (int i in cisla)
            {
                Console.WriteLine("{0} se od mediánu odchyluje o {1}", i, i - median);
            }
            Console.ReadKey();
        }
    }
}