using System;

namespace CSharpCourse.Cviceni3 {
    
    /*
     * Vytvořte aplikaci, evidující dva lidi. Každý člověk má jméno, věk a přítele.
     * Každý člověk se také umí představit a to tak, že vypíše své jméno, věk a jméno svého kamaráda.
     * Vytvořte v aplikaci následující 2 lidi:
     *
     *     "Karel Novák", 33 let
     *     "Josef Nový", 27 let
     *
     * Nechte je se skamarádit a představit se.
     */
    public class Cviceni3 : Cviceni {
        
        public void Run() {
            Clovek karel = new Clovek();
            karel.jmeno = "Karel Novák";
            karel.vek = 33;
            Clovek josef = new Clovek();
            josef.jmeno = "Josef Nový";
            josef.vek = 27;
            karel.PridatKamarada(josef);
            karel.PredstavitSe();
            josef.PredstavitSe();
        }
    }
    
    class Clovek
    {
        public string jmeno;
        public int vek;
        public Clovek kamarad;

        public void PredstavitSe() {
            Console.WriteLine("Ahoj, já jsem {0}, je mi {1} let a můj kamarád je {2}", jmeno, vek, kamarad.jmeno);
        }
        
        public void PridatKamarada(Clovek clovek) {
            this.kamarad = clovek;
            clovek.kamarad = this;
        }
    }
}