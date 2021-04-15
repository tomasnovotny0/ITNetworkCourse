using System;

namespace CSharpCourse {
    class Program {
        static void Main(string[] args) {
            Osoba karel = new Osoba("Karel");
            Osoba lenka = new Osoba("Lenka");
            Pes azor = new Pes("Azor");
            karel.PridatPsa(azor);
            lenka.PridatPsa(azor);
            karel.VratPsa().Zestarni();
            Console.WriteLine(azor);
            lenka.VratPsa().Zestarni(2);
            Console.WriteLine(azor);
        }
    }

    class Osoba {
        private string jmeno;
        private Pes pes;

        public Osoba(string jmeno) {
            this.jmeno = jmeno;
        }

        public void PridatPsa(Pes pes) {
            this.pes = pes;
        }

        public bool MaPsa() {
            return pes != null;
        }

        public Pes VratPsa() {
            return pes;
        }
    }

    class Pes {
        private string jmeno;
        private byte vek;

        public Pes(string jmeno) {
            this.jmeno = jmeno;
        }

        public void Zestarni() {
            Zestarni(1);
        }

        public void Zestarni(byte roky) {
            vek += roky;
        }

        public override string ToString() {
            return string.Format("{0} ({1} let)", jmeno, vek);
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