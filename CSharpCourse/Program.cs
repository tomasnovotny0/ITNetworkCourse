using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpCourse {
    class Program {
        static void Main(string[] args) {
            Hra hra = new Hra();
            while (hra.Bezi()) {
                Console.Write("Zadej příkaz: ");
                string prikaz = Console.ReadLine();
                hra.Akce(prikaz);
            }
        }
    }

    class Hra {
        public readonly Lokace hrad = new Lokace("Hrad", "Stojíš před okovanou branou gotického hradu, která je zřejmě jediným vchodem do pevnosti. Klíčová dírka je pokryta pavučinami, což vzbuzuje dojem, že je budova opuštěná.");
        public readonly Lokace lesHradRozcesti = new Lokace("Les", "Jsi na lesní cestě, která se klikatí až za obzor, kde mizí v siluetě zapadajícího slunce. Ticho podvečerního lesa občas přeruší zpěv posledních ptáků.");
        public readonly Lokace lesniRozcesti = new Lokace("Lesní rozcestí", "Nacházíš se na lesním rozcestí.");
        public readonly Lokace lesRozcestiRybnik = new Lokace("Les", "Jsi na lesní cestě, která se klikatí až za obzor, kde mizí v siluetě zapadajícího slunce. Ticho podvečerního lesa občas přeruší zpěv posledních ptáků.");
        public readonly Lokace rybnik = new Lokace("Rybník", "Došel jsi ke břehu malého rybníka. Hladina je v bezvětří jako zrcadlo. Kousek od tebe je dřevěná plošina se stavidlem.");
        public readonly Lokace lesRozcestiDum = new Lokace("Les", "Jsi na lesní cestě, která se klikatí až za obzor, kde mizí v siluetě zapadajícího slunce. Ticho podvečerního lesa občas přeruší zpěv posledních ptáků.");
        public readonly Lokace dum = new Lokace("Dům", "Stojíš před svým rodným domem, cítíš vůni čerstvě nasekaného dřeva, která se line z hromady vedle vstupních dveří.");
        private bool konec;
        private Lokace aktualniLokace;
        private string[] smery = {"sever", "jih", "východ", "západ"};

        public Hra() {
            hrad.PridejLokaci("východ", lesHradRozcesti);
            lesHradRozcesti.PridejLokaci("západ", hrad);
            lesHradRozcesti.PridejLokaci("východ", lesniRozcesti);
            lesniRozcesti.PridejLokaci("západ", lesHradRozcesti);
            lesniRozcesti.PridejLokaci("východ", lesRozcestiRybnik);
            lesniRozcesti.PridejLokaci("jih", lesRozcestiDum);
            lesRozcestiRybnik.PridejLokaci("západ", lesniRozcesti);
            lesRozcestiRybnik.PridejLokaci("východ", rybnik);
            rybnik.PridejLokaci("západ", lesRozcestiRybnik);
            lesRozcestiDum.PridejLokaci("sever", lesniRozcesti);
            lesRozcestiDum.PridejLokaci("východ", dum);
            dum.PridejLokaci("západ", lesRozcestiDum);

            PresunDoJineLokace(dum);
        }

        public void Akce(string akce) {
            if (akce == "konec") {
                konec = true;
            }
            else {
                string[] inputs = akce.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                if (inputs.Length != 3) {
                    Console.WriteLine("Můj vstupní slovník neobsahuje tento příkaz.");
                } else if (inputs[0] != "jdi" || inputs[1] != "na" || !smery.Contains(inputs[2])) {
                    Console.WriteLine("Můj vstupní slovník neobsahuje tento příkaz.");
                }
                else {
                    string smer = inputs[2];
                    if (!aktualniLokace.ObsahujeLokaciSmerem(smer)) {
                        Console.WriteLine("Tímto směrem nelze jít.");
                        return;
                    }

                    Lokace lokace = aktualniLokace.VratLokaciProSmer(smer);
                    PresunDoJineLokace(lokace);
                }
            }
        }

        public bool Bezi() {
            return !konec;
        }

        private void PresunDoJineLokace(Lokace lokace) {
            aktualniLokace = lokace;
            Console.WriteLine(lokace.VratNazev());
            Console.WriteLine(lokace.VratPopis() + "\n");
            aktualniLokace.VypisMoznosti();
        }
    }

    class Lokace {
        private string nazev;
        private string popis;
        private Dictionary<string, Lokace> mapaLokaci;

        public Lokace(string nazev, string popis) {
            this.nazev = nazev;
            this.popis = popis;
            mapaLokaci = new Dictionary<string, Lokace>(2);
        }

        public void PridejLokaci(string smer, Lokace lokace) {
            mapaLokaci[smer] = lokace;
        }

        public bool ObsahujeLokaciSmerem(string smer) {
            bool naslo;
            try {
                naslo = mapaLokaci[smer] != null;
            }
            catch (KeyNotFoundException e) {
                naslo = false;
            }
            return naslo;
        }

        public Lokace VratLokaciProSmer(string smer) {
            return mapaLokaci[smer];
        }

        public string VratNazev() {
            return nazev;
        }

        public string VratPopis() {
            return popis;
        }

        public void VypisMoznosti() {
            StringBuilder builder = new StringBuilder();
            builder.Append("Můžeš jít na ");
            foreach (KeyValuePair<string, Lokace> pair in mapaLokaci) {
                builder.Append(pair.Key).Append(" ");
            }

            string moznosti = builder.ToString();
            moznosti = moznosti.TrimEnd();
            Console.WriteLine(moznosti);
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