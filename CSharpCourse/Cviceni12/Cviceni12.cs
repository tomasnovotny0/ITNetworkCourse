using System;

namespace CSharpCourse.Cviceni12 {
    
    /*
     * Vytvořte třídu Tvar, která slouží jako předek pro všechny geometrické útvary a která definuje jejich společné vlastnosti.
     * Všechny tvary mají nějakou barvu (string), kterou lze nastavit konstruktorem.
     * Od této třídy následně odvoďte třídy Trojuhelnik a Obdelnik, které budou schopny spočítat svůj obsah.
     * Hierarchie tříd je znázorněna následujícím UML diagramem: (není)
     *
     * K výpočtu obsahu trojúhelníku využijte Heronova vzorce.
     * Heronův vzorec umožňuje vypočítat obsah libovolného trojúhelníku pomocí délek jeho stran.
     *
     * S využitím těchto tříd vypočítejte obsah tohoto obrazce: (strom)
     *
     * 
     */
    public class Cviceni3 : Cviceni {
        
        public void Run() {
            Tvar[] tvary = new Tvar[5];
            for (int i = 0; i < 4; i++) {
                tvary[i] = new Trojuhelnik("zelená", 25, 15);
            }
            tvary[4] = new Obdelnik("hnědá", 3, 26);
            double celkem = 0.0;
            foreach (Tvar tvar in tvary) {
                celkem += tvar.Obsah();
            }

            Console.WriteLine("Obsah stromu je {0} cm^2", celkem);
        }

        class Tvar {

            private string barva;

            public Tvar(string barva) {
                this.barva = barva;
            }
            
            public virtual double Obsah() {
                throw new System.NotImplementedException();
            }
        }

        class Obdelnik : Tvar {

            private int a, b;
            
            public Obdelnik(string barva, int a, int b) : base(barva) {
                this.a = a;
                this.b = b;
            }

            public override double Obsah() {
                return a * b;
            }
        }

        class Trojuhelnik : Tvar {

            private int a, b, c;

            public Trojuhelnik(string barva, int a, int b, int c) : base(barva) {
                this.a = a;
                this.b = b;
                this.c = c;
            }

            public Trojuhelnik(string barva, int podstava, int ramena) : this(barva, ramena, ramena, podstava) {
            }

            public override double Obsah() {
                double s = (a + b + c) / 2.0;
                double S = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
                return S;
            }
        }
    }
}