using System;
using System.Linq;

namespace CSharpCourse {
    class Program {
        static void Main(string[] args) {
            Cviceni5();
            return;
            
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

        /*
         * Vytvořte program, který do konzole vykreslí šachovnici. Pro tmavá pole využijte plný obdélník "█" (napíšete jej jako Alt + 219 nebo si jej
         * zkopírujte z textu do vašeho kódu). Pro světlá pole využijte mezeru.
         * Jelikož znaky v konzoli jsou mnohem vyšší než širší, vypište vždy 2 znaky vedle sebe, aby vypadaly dohromady jako čtverec.
         */
        static void Cviceni4() {
            for (int y = 0; y < 8; y++) {
                for (int x = 0; x < 8; x++) {
                    bool bila = (x + y) % 2 == 0;
                    Console.Write(bila ? "██" : "  ");
                }
                Console.WriteLine("");
            }
        }

        /*
         * Naprogramujte aplikaci, která simuluje hru piškvorky pro 2 hráče.
         * Aplikace vykresluje hrací plochu do konzole a nechává si střídavě od hráčů zadávat souřadnice, na které pokládají své kameny.
         */
        static void Cviceni5() {
            int hrac = 2;
            bool konec = false;
            int[,] plocha = new int[9,9];
            string[] znaky = {" ", "O", "X"};
            string[] hraci = {"nikdo", "hráč s kolečky", "hráč s křížky"};
            while (!konec) {
                Console.Clear();
                Console.Write("  ");
                for (int x = 0; x < plocha.GetLength(0); x++) {
                    Console.Write(x + 1);
                }
                Console.WriteLine();
                for (int y = 0; y < plocha.GetLength(1); y++) {
                    Console.Write(y + 1 + " ");
                    for (int x = 0; x < plocha.GetLength(0); x++) {
                        int znak = plocha[x, y];
                        Console.Write(znaky[znak]);
                    }
                    Console.WriteLine();
                }
                if (!konec) {
                    hrac = hrac == 1 ? 2 : 1;
                    Console.WriteLine("\nNa řadě je {0}", hraci[hrac]);
                    bool prazdnyZnak = false;
                    int x = 1;
                    int y = 1;
                    while (!prazdnyZnak) {
                        Console.Write("Zadej pozici X kam chceš táhnout: ");
                        while (!int.TryParse(Console.ReadLine(), out x)) {
                            Console.WriteLine("Zadej prosím celé číslo");
                        }
                        Console.Write("Zadej pozici Y kam chceš táhnout: ");
                        while (!int.TryParse(Console.ReadLine(), out y)) {
                            Console.WriteLine("Zadej prosím celé číslo");
                        }

                        if (x >= 1 && x <= 9 && y >= 1 && y <= 9 && plocha[x - 1, y - 1] == 0) {
                            prazdnyZnak = true;
                        }
                        else {
                            Console.WriteLine("Neplatná pozice, zadej ji prosím znovu");
                        }

                        plocha[x - 1, y - 1] = hrac;
                    }
                    // kontrola výhry
                    // kontrola řádku
                    int radekX = x;
                    int rada = 1;
                    while (--radekX > 0 && plocha[radekX - 1, y - 1] == hrac) {
                        ++rada;
                    }
                    radekX = x;
                    while (++radekX <= 9 && plocha[radekX - 1, y - 1] == hrac) {
                        ++rada;
                    }
                    if (rada >= 5) {
                        Console.WriteLine("Vyhrál {0}", hraci[hrac]);
                        konec = true;
                        continue;
                    }
                    
                    // kontrola sloupce
                    int radekY = y;
                    rada = 1;
                    while (--radekY > 0 && plocha[x - 1, radekY - 1] == hrac) {
                        ++rada;
                    }
                    radekY = y;
                    while (++radekY <= 9 && plocha[x - 1, radekY - 1] == hrac) {
                        ++rada;
                    }
                    if (rada >= 5) {
                        Console.WriteLine("Vyhrál {0}", hraci[hrac]);
                        konec = true;
                        continue;
                    }
                    
                    // kontrola LR diagonaly
                    radekX = x;
                    radekY = y;
                    rada = 1;
                    while (--radekX > 0 && --radekY > 0 && plocha[radekX - 1, radekY - 1] == hrac) {
                        ++rada;
                    }
                    radekX = x;
                    radekY = y;
                    while (++radekX <= 9 && ++radekY <= 9 && plocha[radekX - 1, radekY - 1] == hrac) {
                        ++rada;
                    }
                    if (rada >= 5) {
                        Console.WriteLine("Vyhrál {0}", hraci[hrac]);
                        konec = true;
                        continue;
                    }
                    
                    // kontrola RL diagonaly
                    radekX = x;
                    radekY = y;
                    rada = 1;
                    while (--radekX > 0 && ++radekY <= 9 && plocha[radekX - 1, radekY - 1] == hrac) {
                        ++rada;
                    }
                    radekX = x;
                    radekY = y;
                    while (++radekX <= 9 && --radekY > 0 && plocha[radekX - 1, radekY - 1] == hrac) {
                        ++rada;
                    }
                    if (rada >= 5) {
                        Console.WriteLine("Vyhrál {0}", hraci[hrac]);
                        konec = true;
                        continue;
                    }
                    
                    // kontrola plné hrací plochy
                    bool nalezenoPrazneMisto = false;
                    for (int i = 0; i < plocha.GetLength(1); i++) {
                        for (int j = 0; j < plocha.GetLength(0); j++) {
                            int znak = plocha[j, i];
                            if (znak == 0) {
                                nalezenoPrazneMisto = true;
                                goto pokracovani;
                            }
                        }
                    }
                    pokracovani:
                    if (!nalezenoPrazneMisto) {
                        konec = true;
                        Console.WriteLine("Remíza.");
                        continue;
                    }
                }
            }

            /*
             * Pomocí goniometrické funkce sinus vykreslete do konzole jednu periodu sinusoidy (grafu této funkce)
             *
             * C# umožňuje posouvat kurzorem po konzoli (slouží k tomu vlastnosti CursorLeft a CursorTop třídy Console).
             * Standardní konzole operačních systémů ovšem tento způsob výpisu často nepodporuje (tedy funguje pouze ve Windows).
             * Proto k řešení úlohy využijeme tzv. buffer. Buffer je pole znaků v paměti, kde si připravíme, jak chceme obrazovku
             * vykreslit, a teprve až je vše, jak potřebujeme, vykreslíme vše naráz.
             * V tomto případě si vytvoříme buffer jako 2D pole o velikosti 79x24 znaků, tedy o 1 znak zprava a zdola menší než okno konzole,
             * protože by jinak při výpisu posledního znaku konzole sama odřádkovala. Do tohoto bufferu zaneseme jednotlivé body sinu.
             * Až budeme mít celý výpočet hotový, teprve poté celý buffer vykreslíme do konzole jako 24 řádků znaků.
             *
             * Perioda funkce sinus je 2 PI, pro průchod přes celou periodu použijte krok = 0.05.
             * Začněte vykreslením této křivky v poměru 1:1, sice bude malá, ale bude v konzoli vidět.
             * Abyste dosáhli výsledku jako na obrázku, musíte souřadnice vynásobit koeficienty
             * (koeficient roztažení v ose x je 12 a koeficient roztažení v ose y je 8).
             * Jednotlivé souřadnice bodů vypočítávejte v desetinných číslech, výsledné souřadnice teprve zaokrouhlíte
             * na celé znaky. Typicky vypočítáte mnohem více bodů, než kolik jich je vidět, protože pozice se zaokrouhlí.
             */
            static void Cviceni6() {
                char[,] buffer = new char[79,24];
                double x = 0;
                double y = 0;
                int rozsireniX = 12;
                int rozsireniY = 8;
                for (int j = 0; j < buffer.GetLength(1); j++) {
                    for (int i = 0; i < buffer.GetLength(0); i++) {
                        buffer[i, j] = ' ';
                    }
                }

                while (x < Math.PI * 2) {
                    y = Math.Sin(x);
                    int consoleX = (int) Math.Round(x * rozsireniX);
                    int consoleY = 12 + (int) Math.Round(y * rozsireniY);
                    buffer[consoleX, consoleY] = '█';
                    x += 0.05;
                }
                
                for (int j = 0; j < buffer.GetLength(1); j++) {
                    for (int i = 0; i < buffer.GetLength(0); i++) {
                        Console.Write(buffer[i, j]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}