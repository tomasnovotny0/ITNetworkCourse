using System;

namespace CSharpCourse {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Vítejte v kalkulačce");
            bool pokracovat = true;
            while (pokracovat.Equals("ano"))
            {
                Console.WriteLine("Zadejte první číslo:");
                float a;
                while (!float.TryParse(Console.ReadLine(), out a)) {
                    Console.WriteLine("Neplatné číslo, zadejte jej prosím znovu:");
                }
                Console.WriteLine("Zadejte druhé číslo:");
                float b;
                while (!float.TryParse(Console.ReadLine(), out b)) {
                    Console.WriteLine("Neplatné číslo, zadejte jej prosím znovu:");
                }
                Console.WriteLine("Zvolte si operaci:");
                Console.WriteLine("1 - sčítání");
                Console.WriteLine("2 - odčítání");
                Console.WriteLine("3 - násobení");
                Console.WriteLine("4 - dělení");
                char volba = Console.ReadKey().KeyChar;
                Console.WriteLine();
                float vysledek = 0;
                bool platnaVolba = true;
                switch (volba)
                {
                    case '1':
                        vysledek = a + b;
                        break;
                    case '2':
                        vysledek = a - b;
                        break;
                    case '3':
                        vysledek = a * b;
                        break;
                    case '4':
                        vysledek = a / b;
                        break;
                    default:
                        platnaVolba = false;
                        break;
                }
                if (platnaVolba)
                    Console.WriteLine("Výsledek: {0}", vysledek);
                else
                    Console.WriteLine("Neplatná volba");
                Console.WriteLine("Přejete si zadat další příklad? [a/n]");
                platnaVolba = false;
                while (!platnaVolba)
                {
                    switch (Console.ReadKey().KeyChar.ToString().ToLower())
                    {
                        case "a":
                            pokracovat = true;
                            platnaVolba = true;
                            break;
                        case "n":
                            pokracovat = false;
                            platnaVolba = true;
                            break;
                        default:
                            Console.WriteLine("Neplatná volba, zadejte prosím a/n");
                            break;
                    }
                }
            }
        }
    }
}