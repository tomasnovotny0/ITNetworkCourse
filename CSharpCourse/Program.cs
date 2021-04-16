using System;
using System.Threading;

namespace CSharpCourse {
    class Program {
        static void Main(string[] args) {
            Kostka kostka = new Kostka(10);
            Bojovnik zalgoren = new Bojovnik("Zalgoren", 100, 20, 10, kostka);
            Bojovnik shadow = new Mag("Shadow", 60, 18, 15, kostka, 30, 45);
            Arena arena = new Arena(zalgoren, shadow, kostka);
            arena.SpustZapas();
            Console.ReadKey();
        }
    }

    class Arena {
        private Bojovnik bojovnik1;
        private Bojovnik bojovnik2;
        private Kostka kostka;

        public Arena(Bojovnik bojovnik1, Bojovnik bojovnik2, Kostka kostka) {
            bool prohodit = kostka.NahodnyBool();
            this.bojovnik1 = prohodit ? bojovnik2 : bojovnik1;
            this.bojovnik2 = prohodit ? bojovnik1 : bojovnik2;
            this.kostka = kostka;
        }

        public void SpustZapas() {
            Console.WriteLine("Vítejte v aréně!");
            Console.WriteLine("Dnes se utkají {0} s {1}! \n", bojovnik1, bojovnik2);
            Console.WriteLine("Zápas může začít...");
            Console.ReadKey();
            while (bojovnik1.JeNazivu()) {
                bojovnik1.Zautoc(bojovnik2);
                Vykresli();
                VypisZpravu(bojovnik1.VratZpravu());
                VypisZpravu(bojovnik2.VratZpravu());
                if (!bojovnik2.JeNazivu()) {
                    break;
                }
                bojovnik2.Zautoc(bojovnik1);
                Vykresli();
                VypisZpravu(bojovnik2.VratZpravu());
                VypisZpravu(bojovnik1.VratZpravu());
                Console.WriteLine();
            }
        }
        
        private void VypisZpravu(string zprava) {
            Console.WriteLine(zprava);
            Thread.Sleep(500);
        }
        
        private void Vykresli() {
            Console.Clear();
            Console.WriteLine("-------------- Aréna -------------- \n");
            Console.WriteLine("Bojovníci:\n");
            VypisBojovnika(bojovnik1);
            Console.WriteLine();
            VypisBojovnika(bojovnik2);
            Console.WriteLine();
        }

        private void VypisBojovnika(Bojovnik bojovnik) {
            Console.WriteLine(bojovnik);
            Console.Write("Život: ");
            Console.WriteLine(bojovnik.ZivotGraficky());
            if (bojovnik is Mag mag)
            {
                Console.Write("Mana:  ");
                Console.WriteLine(mag.ManaGraficky());
            }
        }
    }

    class Mag : Bojovnik {

        private int mana;
        private int maxMana;
        private int magickyUtok;
        
        public Mag(string jmeno, int zivot, int utok, int obrana, Kostka kostka, int mana, int magickyUtok) : base(jmeno, zivot, utok, obrana, kostka) {
            this.maxMana = mana;
            this.mana = mana;
            this.magickyUtok = magickyUtok;
        }

        public override void Zautoc(Bojovnik souper) {
            if (mana == maxMana) {
                int uder = magickyUtok + kostka.Hod();
                NastavZpravu(String.Format("{0} použil magii za {1} hp", jmeno, uder));
                souper.BranSe(uder);
                mana = 0;
            }
            else {
                mana = Math.Min(maxMana, mana + 10);
                base.Zautoc(souper);
            }
        }

        public string ManaGraficky() {
            return GrafickyUkazatel(mana, maxMana);
        }
    }

    class Bojovnik {

        protected string jmeno;
        protected int zivot;
        protected int maxZivot;
        protected int utok;
        protected int obrana;
        protected Kostka kostka;
        private string zprava = "";

        public Bojovnik(string jmeno, int zivot, int utok, int obrana, Kostka kostka) {
            this.jmeno = jmeno;
            this.zivot = zivot;
            this.maxZivot = zivot;
            this.utok = utok;
            this.obrana = obrana;
            this.kostka = kostka;
        }

        public virtual void BranSe(int uder) {
            int zraneni = uder - (obrana + kostka.Hod());
            string zprava;
            if (zraneni > 0) {
                Zran(zraneni);
                zprava = string.Format("{0} utrpěl poškození {1} hp", jmeno, zraneni);
                if (zivot == 0) {
                    zprava += " a zemřel";
                }
            }
            else {
                zprava = string.Format("{0} odrazil útok", jmeno);
            }
            NastavZpravu(zprava);
        }

        public virtual void Zautoc(Bojovnik souper) {
            int uder = utok + kostka.Hod();
            NastavZpravu(string.Format("{0} útočí s úderem za {1} hp", jmeno, uder));
            souper.BranSe(uder);
        }
        
        /// <summary>
        /// Vrací grafickou reprezentaci životů
        /// </summary>
        /// <returns>životy tohoto bojovníka grafiky jako [#####  ]</returns>
        public string ZivotGraficky() {
            return GrafickyUkazatel(zivot, maxZivot);
        }

        protected string GrafickyUkazatel(int hodnota, int maximalniHodnota) {
            string s = "[";
            int celkem = 20;
            double pocet = Math.Round(((double)hodnota / maximalniHodnota) * celkem);
            if (pocet == 0 && JeNazivu())
                pocet = 1;
            for (int i = 0; i < pocet; i++)
                s += "#";
            s = s.PadRight(celkem + 1);
            s += "]";
            return s;
        }
        
        public bool JeNazivu() {
            return zivot > 0;
        }
        
        public override string ToString() {
            return jmeno;
        }

        private void Zran(int pocet) {
            ZmenZivoty(-pocet);
        }
        
        private void ZmenZivoty(int pocet) {
            int noveHp = zivot + pocet;
            zivot = Math.Min(maxZivot, Math.Max(0, noveHp));
        }

        protected void NastavZpravu(string zprava) {
            this.zprava = zprava;
        }

        public string VratZpravu() {
            return zprava;
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

        public bool NahodnyBool() {
            return random.Next(2) == 1;
        }
        
        public override string ToString()
        {
            return String.Format("Kostka s {0} stěnami", pocetSten);
        }
    }
}