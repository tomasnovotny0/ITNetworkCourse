using System;
using System.Threading;

namespace CSharpCourse.Cviceni14 {
    
    /*
     * Naprogramujte aplikaci, která vyrábí cukroví. Každé cukroví má nějakou barvu, tvar a váhu.
     * Existuje např. cukroví banánové, jahodové, čokoládové a další.
     * Jednotlivé druhy cukroví se odlišují pouze hodnotami v atributech.
     * Jelikož by bylo zbytečné tvořit pro každý druh cukroví třídu a zároveň je pracné zadávat konkrétní atributy znovu a znovu tam,
     * kde potřebujeme konkrétní instanci cukroví, použijeme zjednodušenou podobu návrhového vzoru Factory.
     *
     * Factory (továrna) se používá zejména v případě, kdy potřebujete velké množství různě nastavených instancí.
     * Jedná se o třídu se statickými metodami, které vytvoří instanci, nastaví ji určité parametry a takto nastavenou instanci vrátí.
     * Vytvořte takovouto továrnu a implementujte v ní metody pro výrobu banánového, jahodového a čokoládového cukroví.
     * Následně v aplikaci touto továrnou vytvořte a vypište:
     *
     *     5ks banánového cukroví
     *     8ks jahodového cukroví
     *     12ks čokoládového cukroví
     *
     * Vaší továrně nastavte atributy pro dané cukroví podle výstupu níže.
     */
    public class Cviceni14 : Cviceni {
        
        public void Run() {
            TovarnaNaCukrovi.Nastav("žlutá", "kulatý", 20);
            for (int i = 0; i < 5; i++) {
                Console.WriteLine(TovarnaNaCukrovi.VyprodukujInstanci());
            }
            TovarnaNaCukrovi.Nastav("červená", "kulatý", 15);
            for (int i = 0; i < 8; i++) {
                Console.WriteLine(TovarnaNaCukrovi.VyprodukujInstanci());
            }
            TovarnaNaCukrovi.Nastav("hnědá", "hranatý", 25);
            for (int i = 0; i < 12; i++) {
                Console.WriteLine(TovarnaNaCukrovi.VyprodukujInstanci());
            }
        }
    }

    static class TovarnaNaCukrovi {
        private static string barva = "";
        private static string tvar = "";
        private static int vaha = 0;

        public static void Nastav(string barva, string tvar, int vaha) {
            TovarnaNaCukrovi.barva = barva;
            TovarnaNaCukrovi.tvar = tvar;
            TovarnaNaCukrovi.vaha = vaha;
        }

        public static Cukrovi VyprodukujInstanci() {
            return new Cukrovi(barva, tvar, vaha);
        }
    }

    class Cukrovi {
        private string barva;
        private string tvar;
        private int vaha;

        public Cukrovi(string barva, string tvar, int vaha) {
            this.barva = barva;
            this.tvar = tvar;
            this.vaha = vaha;
        }

        public override string ToString() {
            return String.Format("Cukroví barvy {0}, tvaru {1} a váhy {2}g", barva, tvar, vaha);
        }
    }
}