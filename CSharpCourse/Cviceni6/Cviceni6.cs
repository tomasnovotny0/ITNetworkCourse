using System;

namespace CSharpCourse.Cviceni6 {
    
    /*
     * Naprogramujte aplikaci, ve které figuruje auto a garáž.
     * U auta evidujte SPZ a jeho barvu, u garáže evidujte jaké auto je v ní zaparkované (ne jen jeho SPZ, ale opravdu celé auto).
     * Nechte auto s SPZ "123ABC" zaparkovat do garáže (pomocí jeho metody Zaparkuj())
     * a poté nechte vypsat garáž, která při svém výpisu vypíše i auto v ní zaparkované.
     */
    public class Cviceni6 : Cviceni {
        
        public void Run() {
            Auto auto = new Auto("123ABC", "Modrá");
            Garaz garaz = new Garaz();
            garaz.Zaparkuj(auto);
            Console.WriteLine(garaz);
        }
    }
    
    class Auto
    {
        private string spz;
        private string barva;

        public Auto(string spz, string barva) {
            this.spz = spz;
            this.barva = barva;
        }

        public override string ToString() {
            return spz;
        }
    }
    
    class Garaz
    {
        private Auto auto;

        public void Zaparkuj(Auto auto) {
            this.auto = auto;
        }

        public override string ToString() {
            return string.Format("V garáži je auto: {0}", auto);
        }
    }
}