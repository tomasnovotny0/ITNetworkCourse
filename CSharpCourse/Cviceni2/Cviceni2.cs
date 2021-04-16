using System;

namespace CSharpCourse.Cviceni2 {
    
    /*
     * S použitím objektově orientovaného programování vytvořte aplikaci, ve které figuruje nákladní auto, které převáží písek.
     * Toto auto má nosnost 3 tuny a jeho náklad je zpočátku prázdný. Nechte auto postupně:
     *
     * naložit 10 tun
     * naložit 500 kg
     * vyložit 300 kg
     * vyložit 1 tunu
     *
     * Jak asi tušíte, naložení a vyložení nákladu bude probíhat pomocí metod, které si před změnou váhy nákladu nejprve ověří,
     * zda je v autě dost místa nebo zda nevykládáme více, než je naloženo. V případě chyby se náklad nevloží/nevyloží.
     * Po dokončení nakládání a vykládání nechte vypsat kolik je v autě kg nákladu, mělo by vám vyjít 200 kg.
     */
    public class Cviceni2 : Cviceni {
        
        public void Run() {
            NakladniAuto auto = new NakladniAuto();
            auto.Nalozit(10000);
            auto.Nalozit(500);
            auto.Vylozit(300);
            auto.Vylozit(1000);
            Console.WriteLine("V nákladním autě je naloženo {0} kg", auto.Vaha());
        }
    }
    
    class NakladniAuto
    {
        private const int nosnost = 3000;
        private int naklad;

        public void Nalozit(int kg) {
            int novaVaha = naklad + kg;
            if (novaVaha <= nosnost) {
                naklad = novaVaha;
            }
        }

        public void Vylozit(int kg) {
            int novaVaha = naklad - kg;
            if (novaVaha >= 0) {
                naklad = novaVaha;
            }
        }

        public int Vaha() {
            return naklad;
        }
    }
}