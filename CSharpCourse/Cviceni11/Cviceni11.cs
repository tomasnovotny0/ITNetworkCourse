using System;

namespace CSharpCourse.Cviceni11 {
    
    /*
     * Třídu Clovek poděďte ve třídě Javista. Javista (vím, že máme C#, ale "síšarpista" zní divně :)) člověka rozšiřuje o atribut IDE,
     * kde je uložen název vývojového prostředí, ve kterém programuje. Atribut se zadává spolu s dalšími atributy Javisty v konstruktoru.
     * Javista dále disponuje metodou Programuj(), která přijímá v parametru počet řádků, která má napsat.
     * Za každých 10 řádku přidejte jednotku únavy a zároveň únavu nenechte vzrůst nad 20 jednotek.
     * V případě příliš vysoké únavy metoda vypíše "Jsem příliš unavený, abych programoval".
     *
     * V aplikaci vytvořte Javistu jménem "Karel Nový" s věkem 25 let a vypište ji do konzole.
     * Karla nechte uběhnout 2x 10 km.
     * Nechte jej naprogramovat 5 řádků.
     * Dále běhat 10 km.
     * Spát 8 hodin.
     * Naprogramovat 100 řádků.
     */
    public class Cviceni2 : Cviceni {
        
        public void Run() {
            Javista javista = new Javista("Jetbrains Rider", "Karel Nový", 25);
            Console.WriteLine(javista);
            for (int i = 0; i < 2; i++) {
                javista.Behej(10);
            }
            javista.Programuj(5);
            javista.Behej(10);
            javista.Spi(8);
            javista.Programuj(100);
        }
    }

    class Javista : Clovek {

        private string IDE;
        public Javista(string IDE, string jmeno, int vek) : base(jmeno, vek) {
            this.IDE = IDE;
        }

        public void Programuj(int radky) {
            int unaveni = Math.Max(1, radky / 10);
            int novaUnava = unava + unaveni;
            if (novaUnava > 20) {
                Console.WriteLine("Jsem příliš unavený, abych programoval");
            }
            else {
                unava = novaUnava;
            }
        }
    }

    class Clovek {

        private string jmeno;
        private int vek;
        protected int unava = 0;
        
        public Clovek(string jmeno, int vek)
        {
            this.jmeno = jmeno;
            this.vek = vek;
        }
        
        public void Spi(int doba)
        {
            unava -= doba * 10;
            if (unava < 0)
                unava = 0;
        }
        
        public void Behej(int vzdalenost)
        {
            if (unava + vzdalenost <= 20)
                unava += vzdalenost;
            else
                Console.WriteLine("Jsem příliš unavený");
        }
        
        public override string ToString()
        {
            return string.Format("{0} ({1})", jmeno, vek);
        }
    }
}