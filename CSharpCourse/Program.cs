using System;

namespace CSharpCourse {
    class Program {
        static void Main(string[] args) {
            
        }

        static void Cviceni1() {
            Console.WriteLine("Zadej jméno:");
            string jmeno = Console.ReadLine();
            Console.WriteLine("Zadej příjmení:");
            string prijmeni = Console.ReadLine();
            Console.WriteLine("Zadej svůj věk:");
            byte vek = byte.Parse(Console.ReadLine());
            Console.WriteLine((jmeno + " " + prijmeni).ToUpper());
            Console.WriteLine("Za rok ti bude " + (vek + 1) + " let.");
        }

        static void Cviceni2() {
            Console.WriteLine("Zadejte delší slovo:");
            string prvniSlovo = Console.ReadLine().Trim();
            Console.WriteLine("Zadejte kratší slovo:");
            string druheSlovo = Console.ReadLine().Trim();
            int rozdil = prvniSlovo.Length - druheSlovo.Length;
            Console.WriteLine("Slova se liší délkou o {0} znaků", rozdil);
        }

        static void Cviceni3() {
            Console.WriteLine("Zadej řetězec:");
            string retezec = Console.ReadLine();
            Console.WriteLine(retezec.ToLower().Contains("itnetwork"));
        }
    }
}