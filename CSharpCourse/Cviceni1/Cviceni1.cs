using System;

namespace CSharpCourse.Cviceni1 {
    
    /*
     * Vytvořte třídu kalkulačka, jejíž atributy jsou dvě čísla.
     * Třídě vytvořte metody pro základní početní operace (sčítání, odčítání, násobení, dělení),
     * které vracejí vždy výsledek dané operace s atributy třídy.
     * V praxi by metody samozřejmě dělaly nějaké složitější výpočty, ale nám to takto stačí.
     * Nechte uživatele zadat oba atributy, vytvořte instanci kalkulačky, nastavte jí atributy od uživatele a vypište výsledky jednotlivých operací.
     */
    public class Cviceni1 : Cviceni {
        
        public void Run() {
            Console.Write("Zadej 1. číslo: ");
            double prvniCislo = double.Parse(Console.ReadLine());
            Console.Write("Zadej 2. číslo: ");
            double druheCislo = double.Parse(Console.ReadLine());
            Kalkulacka kalkulacka = new Kalkulacka();
            kalkulacka.cislo1 = prvniCislo;
            kalkulacka.cislo2 = druheCislo;
            Console.WriteLine("Součet: {0}", kalkulacka.Soucet());
            Console.WriteLine("Rozdíl: {0}", kalkulacka.Rozdil());
            Console.WriteLine("Součin: {0}", kalkulacka.Nasobeni());
            Console.WriteLine("Podíl: {0}", kalkulacka.Deleni());
        }
    }
    
    class Kalkulacka
    {
        public double cislo1;
        public double cislo2;

        public double Soucet() {
            return cislo1 + cislo2;
        }

        public double Rozdil() {
            return cislo1 - cislo2;
        }

        public double Nasobeni() {
            return cislo1 * cislo2;
        }

        public double Deleni() {
            return cislo1 / cislo2;
        }
    }
}