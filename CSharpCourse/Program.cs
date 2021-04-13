using System;

namespace CSharpCourse {
    class Program {
        static void Main(string[] args) {
            // for
            for (int i = 1; i <= 10; i++) {
                Console.Write("{0} ", i);
            }
            Console.WriteLine("\n");
            
            // malá násobilka pomocí cyklu for
            for (int i = 1; i <= 10; i++) {
                for (int j = 1; j <= 10; j++) {
                    Console.Write("{0} ", i * j);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            
            // mocniny pomocí cyklu
            Console.WriteLine("Zadejte základ mocniny:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Zadejte exponent:");
            int e = int.Parse(Console.ReadLine());
            int vysledek = n;
            for (int i = 0; i < (e - 1); i++) {
                vysledek *= n;
            }

            Console.WriteLine("Výsledek: {0}", vysledek);
            
            // while
            int k = 1;
            while (k <= 10) {
                Console.Write("{0} ", k);
                k++;
            }
            Console.WriteLine();
            
            // upravená kalkulačka pomocí while cyklu
            SpustitKalkulacku();
            
            // operátory ++ a --
            // promenna++, promenna-- => vrátí současnou hodnotu a pak zvýší/sníží hodnotu proměnné
            // ++promenna, --promenna => zvýší/sníží hodnotu proměnné a vrátí upravenou hodnotu
        }

        static void SpustitKalkulacku() {
            Console.WriteLine("Vítejte v kalkulačce");
            string pokracovat = "ano";
            while (pokracovat == "ano")
            {
                Console.WriteLine("Zadejte první číslo:");
                float a = float.Parse(Console.ReadLine());
                Console.WriteLine("Zadejte druhé číslo:");
                float b = float.Parse(Console.ReadLine());
                Console.WriteLine("Zvolte si operaci:");
                Console.WriteLine("1 - sčítání");
                Console.WriteLine("2 - odčítání");
                Console.WriteLine("3 - násobení");
                Console.WriteLine("4 - dělení");
                int volba = int.Parse(Console.ReadLine());
                float vysledek = 0;
                switch (volba)
                {
                    case 1:
                        vysledek = a + b;
                        break;
                    case 2:
                        vysledek = a - b;
                        break;
                    case 3:
                        vysledek = a * b;
                        break;
                    case 4:
                        vysledek = a / b;
                        break;
                }
                if ((volba > 0) && (volba < 5))
                    Console.WriteLine("Výsledek: {0}", vysledek);
                else
                    Console.WriteLine("Neplatná volba");
                Console.WriteLine("Přejete si zadat další příklad? [ano/ne]");
                pokracovat = Console.ReadLine();
            }
            Console.WriteLine("Děkuji za použití kalkulačky, aplikaci ukončíte libovolnou klávesou.");
        }

        /*
         * Vytvořte program, který se uživatele zeptá, kolik si dá ryb k večeři. Poté mu do konzole vypíše zadaný počet ryb tímto způsobem:
         *     <° )))-<
         */
        static void Cviceni1() {
            Console.WriteLine("Kolik ryb si dáš k večeři?");
            int pocetRyb = int.Parse(Console.ReadLine());
            for (int i = 0; i < pocetRyb; i++) {
                Console.WriteLine("<° )))-<");
            }
        }

        /*
         * Zadání tohoto programu je odvozeno z anglické říkanky, která začíná takto:
         *     10 zelených láhví stojí na stole a jedna láhev spadne
         *
         * Program dále pokračuje takto:
         *     9 zelených láhví stojí na stole a jedna láhev spadne
         *
         * Až skončí poslední větou:
         *     1 zelená láhev stojí na stole a jedna láhev spadne
         *
         * Vytvořte program, který provede takovýto výstup pro 10 láhví.
         * Všimněte si, že program umí skloňovat slova zelená a láhev.
         */
        static void Cviceni2() {
            for (int pocetLahvi = 10; pocetLahvi > 0; pocetLahvi--) {
                string zelene;
                string lahev;
                if (pocetLahvi >= 5) {
                    zelene = "zelených";
                    lahev = "láhví";
                } else if (pocetLahvi > 1) {
                    zelene = "zelené";
                    lahev = "láhve";
                } else {
                    zelene = "zelená";
                    lahev = "láhev";
                }
                Console.WriteLine("{0} {1} {2} stojí na stole a jedna láhev spadne", pocetLahvi, zelene, lahev);
            }
        }

        /*
         * Vytvořte program, který si nechá na vstupu zadat 2 intervaly (vždy dolní a horní mez jako celé číslo).
         * Následně vypíše všechny dvojice čísel (z prvního a druhého intervalu), jejichž součet leží alespoň v jednom z intervalů.
         */
        static void Cviceni3() {
            Console.WriteLine("Zadejte levou mez 1. intervalu:");
            int prvniMin = int.Parse(Console.ReadLine());
            Console.WriteLine("Zadejte pravou mez 1. intervalu:");
            int prvniMax = int.Parse(Console.ReadLine());
            Console.WriteLine("Zadejte levou mez 2. intervalu:");
            int druhyMin = int.Parse(Console.ReadLine());
            Console.WriteLine("Zadejte pravou mez 2. intervalu:");
            int druhyMax = int.Parse(Console.ReadLine());

            Console.WriteLine("Dvojice čísel, jejichž součet leží v některém z intervalů:");
            Console.WriteLine("(1. číslo je z prvního intervalu a 2. z druhého intervalu)");
            for (int i = prvniMin; i <= prvniMax; i++) {
                for (int j = druhyMin; j <= druhyMax; j++) {
                    int soucet = i + j;
                    if (soucet >= prvniMin && soucet <= prvniMax || soucet >= druhyMin && soucet <= druhyMax) {
                        Console.Write("[{0};{1}], ", i, j);
                    }
                }
            }
        }
    }
}