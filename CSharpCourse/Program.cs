﻿using System;

namespace CSharpCourse {
    class Program {
        static void Main(string[] args) {
            Rodokmen rodokmen = new Rodokmen();
            Console.WriteLine("Rodokmen pro osobu {0}", rodokmen.bartSimpson);
            rodokmen.VypisOsobu(rodokmen.bartSimpson);
            Console.WriteLine();
            Console.WriteLine("Rodokmen pro osobu {0}", rodokmen.homerSimpson);
            rodokmen.VypisOsobu(rodokmen.homerSimpson);
        }
    }

    class Rodokmen {

        public readonly Osoba homerSimpson;
        public readonly Osoba bartSimpson;
        
        public Rodokmen() {
            Osoba abrahamS = new Osoba("Abraham Simpson");
            Osoba penelopeO = new Osoba("Penelope Olsen");
            Osoba herbP = new Osoba("Herb Powers");
            homerSimpson = new Osoba("Homer Simpson");
            herbP.NastavRodice(abrahamS, penelopeO);
            homerSimpson.NastavRodice(abrahamS, penelopeO);
            Osoba panB = new Osoba("Pan Bouvier");
            Osoba jackieB = new Osoba("Jackie Bouvier");
            Osoba margeB = new Osoba("Marge Bouvier");
            Osoba selmaB = new Osoba("Selma Bouvier");
            margeB.NastavRodice(panB, jackieB);
            selmaB.NastavRodice(panB, jackieB);
            bartSimpson = new Osoba("Bart Simpson");
            bartSimpson.NastavRodice(homerSimpson, margeB);
        }

        public void VypisOsobu(Osoba osoba) {
            if (osoba != null) {
                Console.WriteLine(osoba);
                VypisOsobu(osoba.VratOtce());
                VypisOsobu(osoba.VratMatku());
            }
        }
    }

    class Osoba {
        private string jmeno;
        private Osoba otec;
        private Osoba matka;

        public Osoba(string jmeno) {
            this.jmeno = jmeno;
        }

        public void NastavRodice(Osoba otec, Osoba matka) {
            this.otec = otec;
            this.matka = matka;
        }

        public Osoba VratOtce() {
            return otec;
        }

        public Osoba VratMatku() {
            return matka;
        }

        public override string ToString() {
            return jmeno;
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