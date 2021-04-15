using System;

namespace CSharpCourse {
    class Program {
        static void Main(string[] args) {
            Auto auto = new Auto("123ABC", "Modrá");
            Garaz garaz = new Garaz();
            garaz.Zaparkuj(auto);
            Console.WriteLine(garaz);
        }
    }

    class Auto {
        private string spz;
        private string barva;

        public Auto(string spz, string barva) {
            this.spz = spz;
            this.barva = barva;
        }

        public override string ToString() {
            return spz;
        }
    }

    class Garaz {
        private Auto auto;

        public void Zaparkuj(Auto auto) {
            this.auto = auto;
        }

        public override string ToString() {
            return string.Format("V garáži je auto: {0}", auto);
        }
    }

    /// <summary>
    /// Třída reprezentuje hrací kostku
    /// </summary>
    class Kostka {

        private Random random;
        private int pocetSten;

        public Kostka(int pocetSten) {
            random = new Random();
            this.pocetSten = pocetSten;
        }

        public Kostka() : this(6) {
        }

        /// <summary>
        /// Vrátí počet stěn hrací kostky
        /// </summary>
        /// <returns>počet stěn hrací kostky</returns>
        public int VratPocetSten() {
            return pocetSten;
        }

        public int Hod() {
            return random.Next(1, pocetSten + 1);
        }
        
        public override string ToString()
        {
            return String.Format("Kostka s {0} stěnami", pocetSten);
        }
    }
}