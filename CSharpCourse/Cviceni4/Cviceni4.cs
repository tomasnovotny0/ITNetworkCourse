using System;

namespace CSharpCourse.Cviceni4 {
    
    /*
     * Naprogramujte aplikaci, která obsluhuje člověka.
     * Člověk má jméno a únavu, která je zpočátku 0. Může uběhnout určitou vzdálenost a také spát určitou dobu.
     * Běháním se jeho únava zvyšuje (1 jednotka únavy na 1 km), spaním se snižuje (10 jednotek únavy na 1 hodinu).
     * Navrhněte třídu tak, aby se únava nikdy nemohla dostat z rozmezí 0-20 jednotek.
     * Samozřejmě vám k tomu pomůže zapouzdření, únava určitě nebude veřejným atributem.
     *
     * Program vyzkoušíte tak, že necháte člověk 3x uběhnout 10 km. Třetí uběhnutí by se nemělo povést.
     * Když člověka necháte po druhém uběhnutí hodinu spát, zvládne i třetí běh.
     * Na úvod vypište instanci člověka. Definujte mu metodu ToString() tak, aby se vypsalo jeho jméno a věk.
     */
    public class Cviceni4 : Cviceni {
        
        public void Run() {
            Clovek clovek = new Clovek("Karel Nový");
            clovek.Behat(25);
            clovek.Spat(1);
            clovek.Behat(10);
            Console.WriteLine("{0}", clovek);
            clovek.Behat(5);
        }
    }
    
    class Clovek
    {
        private string jmeno;
        private int unava;

        public Clovek(String jmeno) {
            this.jmeno = jmeno;
        }

        public void Behat(int km) {
            if (unava > 20) {
                Console.WriteLine("Jsem příliš unavený");
                return;
            }
            unava += km;
        }

        public void Spat(int hodin) {
            unava = Math.Max(0, unava - hodin * 10);
        }
        
        public override string ToString() {
            return string.Format("{0} ({1})", jmeno, unava);
        }
    }
}