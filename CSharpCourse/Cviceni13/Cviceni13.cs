using System;

namespace CSharpCourse.Cviceni13 {
    
    /*
     * Naprogramujte aplikaci pro převod mezi stupni a radiány.
     * Jelikož vše, co jste se učili ve škole, bylo ve stupních a vše, co se budete učit v programování,
     * bude v radiánech, bude se vám znalost převodu hodit i do budoucna.
     * Pokud vzorec neznáte, určitě si jej zvládnete jednoduše vyhledat :)
     * Pro číslo Pí ve vzorci použijte konstantu na třídě Math. V aplikaci pro převody použijte statickou třídu.
     */
    public class Cviceni13 : Cviceni {
        
        public void Run() {
            double radiany = 6.28;
            double stupne = 90;
            Console.WriteLine("{0} radiánů na stupně: {1}", radiany, Prevodnik.PrevedNaStupne(radiany));
            Console.WriteLine("{0} stupňů na radiány: {1}", stupne, Prevodnik.PrevedNaRadiany(stupne));
        }
    }
}