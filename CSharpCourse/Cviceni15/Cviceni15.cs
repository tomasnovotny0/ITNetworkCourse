using System;

namespace CSharpCourse.Cviceni15 {
    
    /*
     * Vytvořte hrací kostku, která obsahuje metodu Hod().
     * Je to ta samá kostka, jakou jsme tvořili na začátku seriálu.
     * Hod() vrací náhodné číslo od 1 do 6. Vytvořte 2 instance těchto kostek a nechte je v cyklu 10x hodit.
     */
    public class Cviceni15 : Cviceni {
        
        public void Run() {
            Kostka k1 = new Kostka();
            Kostka k2 = new Kostka();
            for (int i = 0; i < 10; i++) {
                Console.WriteLine("Na první kostce padlo {0}", k1.Hod());
                Console.WriteLine("Na druhé kostce padlo {0}", k2.Hod());
            }
        }
    }

    class Kostka {
        private Random random;

        public Kostka() {
            random = new Random();
        }

        public int Hod() {
            return random.Next(1, 7);
        }
    }
}