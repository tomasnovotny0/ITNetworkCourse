using System;

namespace CSharpCourse.Cviceni10 {
    
    /*
     * V aplikaci vytvořte třídu Ptak s atributy:
     *     hlad = výchozí hodnota 100 jednotek
     *     vaha = výchozí hodnota 50 gramů
     *
     * Třídě dodejte metodu Snez(), která přijímá kolik gramů potravy má pták sníst.
     * Váha ptáka se po snědení potravy zvýší o váhu potravy a hlad se o toto množství sníží.
     * Následně přidejte třídu AngryPtak, který ptáka rozšiřuje o atribut vztek s výchozí hodnotou 50 a metodu Provokuj().
     * Tato metoda přijímá jako parametr míru provokoce, která zvýší vztek ptáka. Pokud je pták hladový,
     * naštve se 2x rychleji (přičte se mu tedy dvojnásobek míry provokace, než kolik bylo metodě předáno).
     * Třídy nemusí pro zjednodušení vůbec obsahovat konstruktory.
     *
     * Nejprve ve své aplikaci vytvořte instanci ptáka a vypište ji.
     * Následně ji nechte sníst 20g potravy a opět ji vypište.
     * Dále vytvořte instanci angry ptáka a vypište ji.
     * Instanci angry ptáka provokujte s mírou provokace 5 a vypište.
     * Dále ji nechte sníst 100g potravy a opět provokujte s mírou provokace 5. Výslednou instanci opět vypište.
     */
    public class Cviceni1 : Cviceni {
        
        public void Run() {
            Ptak ptak = new Ptak();
            Console.WriteLine(ptak);
            ptak.Snez(20);
            Console.WriteLine(ptak);
            AngryPtak angryPtak = new AngryPtak();
            Console.WriteLine(angryPtak);
            angryPtak.Provokuj(5);
            Console.WriteLine(angryPtak);
            angryPtak.Snez(100);
            angryPtak.Provokuj(5);
            Console.WriteLine(angryPtak);
        }
    }

    class Ptak {
        protected int hlad;
        protected int vaha;

        public Ptak() {
            hlad = 100;
            vaha = 50;
        }

        public void Snez(int mnozstvi) {
            hlad -= mnozstvi;
            vaha += mnozstvi;
        }

        public bool JeHladovy() {
            return hlad > 0;
        }

        public override string ToString() {
            return String.Format("Jsem pták s váhou {0} a hladem {1}.", vaha, hlad);
        }
    }

    class AngryPtak : Ptak {

        private int vztek;

        public AngryPtak() {
            vztek = 50;
        }

        public void Provokuj(int mnozstvi) {
            if (JeHladovy()) {
                mnozstvi += mnozstvi;
            }

            vztek += mnozstvi;
        }

        public override string ToString() {
            return String.Format("Jsem angry-pták s váhou {0} a hladem {1}, míra mého vzteku je {2}.", vaha, hlad, vztek);
        }
    }
}