using System;

namespace CSharpCourse.Cviceni5 {
    
    /*
     * Naprogramujte za pomoci OOP generátor náhodných vět. Nechte ho vygenerovat 10 vět a tyto věty vypište do konzole.
     * Svůj generátor vybavte následující slovní zásobou:
     *     Podměty: jednorožec, programátor, manažer, hroch, T-rex
     *     Přísudky: spal, ležel, vařil, uklízel, derivoval
     *     Přívlastky: modrý, velký, hubený, nejlepší, automatizovaný
     *     Příslovce: rychle, s oblibou, hodně, málo, se zpožděním
     *     Příslovečná určení místa: pod stolem, v lese, u babičky, v práci, na stole
     */
    public class Cviceni5 : Cviceni {
        
        public void Run() {
            GeneratorVet generatorVet = new GeneratorVet();
            for (int i = 0; i < 10; i++) {
                Console.WriteLine(generatorVet.VygenerujVetu());
            }
        }
    }
    
    class GeneratorVet
    {
        private string[] podmety = {"jednorožec", "programátor", "manažer", "hroch", "T-rex"};
        private string[] prisudky = {"spal", "ležel", "vařil", "uklízel", "derivoval"};
        private string[] privlastky = {"modrý", "velký", "hubený", "nejlepší", "automatizovaný"};
        private string[] prislovce = {"rychle", "s oblibou", "hodně", "málo", "se zpožděním"};
        private string[] pums = {"pod stolem", "v lese", "u babičky", "v práci", "na stole"};
        private Random random = new Random();

        public string VygenerujVetu() {
            string podmet = VratNahodnyElement(podmety);
            string prisudek = VratNahodnyElement(prisudky);
            string privlastek = VratNahodnyElement(privlastky);
            string prislovce = VratNahodnyElement(this.prislovce);
            string pum = VratNahodnyElement(pums);
            return String.Format("{0} {1} {2} {3} {4}", privlastek, podmet, prislovce, prisudek, pum);
        }

        private T VratNahodnyElement<T>(T[] elementy) {
            return elementy[random.Next(elementy.Length)];
        }
    }
}