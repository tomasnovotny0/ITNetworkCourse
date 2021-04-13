using System;
using System.Threading;

namespace CSharpCourse {
    class Program {
        static void Main(string[] args) {
            if (15 > 5)
                Console.WriteLine("Pravda");
            // program pokračuje dál
            
            
            Console.WriteLine("Zadej nějaké číslo");
            int a = int.Parse(Console.ReadLine());
            if(a > 5)
                Console.WriteLine("Zadal jsi číslo větší než 5");
            Console.WriteLine("Děkuji za zadání");

            Console.WriteLine("Zadej číslo, ze kterého spočítám odmocninu");
            int b = int.Parse(Console.ReadLine());
            if (b <= 0) {
                double odmocnina = Math.Sqrt(b);
                Console.WriteLine("Odmocnina z čísla {0} je {1}", b, odmocnina);
            }
            else {
                Console.WriteLine("Odmocnina ze záporného čísla neexistuje!");
            }
            
            
            
            Console.WriteLine("Zadejte číslo v rozmezí 10-20 nebo 30-40:");
            int c = int.Parse(Console.ReadLine());
            if (((c >= 10) && (c <= 20)) || ((c >=30) && (c <= 40)))
                Console.WriteLine("Zadal jsi správně");
            else
                Console.WriteLine("Zadal jsi špatně");
            
            
            // switch
            Console.WriteLine("Vítejte v kalkulačce");
            Console.WriteLine("Zadejte první číslo:");
            float d = float.Parse(Console.ReadLine());
            Console.WriteLine("Zadejte druhé číslo:");
            float e = float.Parse(Console.ReadLine());
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
                    vysledek = d + e;
                    break;
                case 2:
                    vysledek = d - e;
                    break;
                case 3:
                    vysledek = d * e;
                    break;
                case 4:
                    vysledek = d / e;
                    break;
            }
            if ((volba > 0) && (volba < 5))
                Console.WriteLine("Výsledek: {0}", vysledek);
            else
                Console.WriteLine("Neplatná volba");
            Console.WriteLine("Děkuji za použití kalkulačky, aplikaci ukončíte libovolnou klávesou.");
            
            // Není doporučeno používat
            int teplota = 12;
            string teplotaSlovy = teplota switch
            {
                < -5 => "Mrzne",
                >= -5 and <= 5 => "Zima",
                > 5 and < 15 => "Chladno",
                >= 15 and <= 25 => "Teplo",
                > 25 => "Horko",
            };
            // _=> nahrazuje 'default'
        }

        /*
         * Vytvořte program, který si na vstupu nechá zadat jméno uživatele. Program analyzuje délku zadaného jména.
         * Pokud je délka jména mezi třemi a deseti znaky, vypíše "Normální jméno.".
         * V ostatních případech vypíše "Máš moc krátké nebo moc dlouhé jméno!".
         */
        static void Cviceni1() {
            Console.WriteLine("Zadej své jméno:");
            string jmeno = Console.ReadLine();
            if (jmeno.Length >= 3 && jmeno.Length <= 10) {
                Console.WriteLine("Normální jméno.");
            }
            else {
                Console.WriteLine("Máš moc krátké nebo moc dlouhé jméno!");
            }
        }

        /*
         * Vytvořte program, který si na vstupu nechá zadat smajlíka. Následně vypište slovy o jakou emoci se jedná.
         * Rozeznávejte následující smajlíky a vypište k nim tyto texty:
         *     :-) - "Tvůj smajlík je veselý"
         *     :-( - "Tvůj smajlík je smutný"
         *     :-* - "Tvůj smajlík je zamilovaný"
         *     :-P - "Tvůj smajlík je s vyplazeným jazykem"
         *     jakýkoli jiný - "Tvůj smajlík je neznámý"
         *
         * K řešení aplikace použijte konstrukci switch.
         * Dále se zamyslete nad tím, aby program rozeznával smajlíky s nosem i bez nosu.
         */
        static void Cviceni2() {
            Console.WriteLine("Zadej smajlíka:");
            string smajlik = Console.ReadLine().Replace("-", "");
            switch (smajlik) {
                case ":)":
                    Console.WriteLine("Tvůj smajlík je veselý");
                    break;
                case ":(":
                    Console.WriteLine("Tvůj smajlík je smutný");
                    break;
                case ":*":
                    Console.WriteLine("Tvůj smajlík je zamilovaný");
                    break;
                case ":P":
                    Console.WriteLine("Tvůj smajlík je s vyplazeným jazykem");
                    break;
                default:
                    Console.WriteLine("Tvůj smajlík je neznámý");
                    break;
            }
        }

        /*
         * Vytvořte program, který si na vstupu vyžádá postupně koeficienty a, b, c kvadratické rovnice ax2 + bx + c = 0 a vypočítá její
         * reálné kořeny pomocí diskriminantu. Vzoreček pro výpočet diskriminantu je:
         *     d = b2 - 4 * a * c
         *
         * A vzoreček pro výpočet kořenů je:
         *     x1 = (-b + odmocnina(d)) / 2a
         *     x2 = (-b - odmocnina(d)) / 2a
         *
         * Komplexními kořeny se nezabývejte, při záporném diskriminantu tedy program vypíše, že rovnice nemá řešení.
         */
        static void Cviceni3() {
            Console.WriteLine("Zadejte postupně koeficienty a,b,c kvadratické rovnice ax^2+bx+c=0 :");
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            if (a == 0) {
                Console.WriteLine("Není kvadratická rovnice");
                return;
            }
            double d = b * b - 4 * a * c;
            if (d < 0) {
                Console.WriteLine("Neexistuje řešení v oblasti reálných čísel");
            }
            else if (d == 0) {
                double x = (-b + Math.Sqrt(d)) / (2 * a);
                Console.WriteLine("Rovnice má jeden kořen x = {0}", x);
            }
            else {
                double x1 = (-b + Math.Sqrt(d)) / (2 * a);
                double x2 = (-b - Math.Sqrt(d)) / (2 * a);
                Console.WriteLine("Rovnice má 2 reálné kořeny x1 = {0}, x2 = {1}", x1, x2);
            }
        }
    }
}