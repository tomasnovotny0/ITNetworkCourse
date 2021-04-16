using System;

namespace CSharpCourse.Cviceni9 {
    
    /*
     * Naprogramujte aplikaci evidující rodokmen Barta Simpsona a Homera Simpsona
     *
     * V aplikaci budou figurovat osoby. Každá osoba má referenci na otce a matku, kteří jsou sami osobami.
     * Sestavte v paměti strom z napojených instancí osob tak, jak je na obrázku výše.
     * V druhém kroku se pokuste vypsat rodokmeny Barta Simpsona a Homera Simpsona tak, jak je to vidět na screenshotu níže.
     */
    public class Cviceni9 : Cviceni {
        
        public void Run() {
            Rodokmen rodokmen = new Rodokmen();
            Console.WriteLine("Rodokmen pro osobu {0}", rodokmen.bartSimpson);
            rodokmen.VypisOsobu(rodokmen.bartSimpson);
            Console.WriteLine();
            Console.WriteLine("Rodokmen pro osobu {0}", rodokmen.homerSimpson);
            rodokmen.VypisOsobu(rodokmen.homerSimpson);
        }
    }
    
    class Osoba
    {
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
    
    class Rodokmen
    {
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
}