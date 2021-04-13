using System;

namespace CSharpCourse {
    class Program {
        static void Main(string[] args) {
        }
        
        static void Cviceni1() {
            Console.WriteLine("Hi, what is your name?");
            string name = Console.ReadLine();
            Console.WriteLine("What are you like?");
            string property = Console.ReadLine();
            Console.WriteLine("{0} is {1}", name, property);
            Console.ReadKey();
        }
        
        static void Cviceni2() {
            Console.WriteLine("Zadej číslo k umocnění:");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Výsledek: " + number * number);
            Console.ReadKey();
        }
        
        static void Cviceni3() {
            float PI = 3.1415F;
            Console.WriteLine("Zadej poloměr kruhu (cm):");
            float radius = float.Parse(Console.ReadLine());
            float perimeter = 2 * PI * radius;
            float radius2 = radius * radius;
            float area = PI * radius2;
            Console.WriteLine("Obvod zadaného kruhu je: {0} cm", perimeter);
            Console.WriteLine("Jeho obsah je {0} cm^2", area);
            Console.ReadKey();
        }
    }
}