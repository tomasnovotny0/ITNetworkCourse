using System;

namespace CSharpCourse.Cviceni7 {
    
    /*
     * Naprogramujte aplikaci, ve které figurují dva typy objektů - Pes a Osoba.
     * Pes má jméno, věk a metodu, která ho nechá zestárnout o jeden rok. Osoba má jméno a psa.
     * V aplikaci si vytvořte jednoho psa a vypište jeho věk. Tohoto psa následně přiřaďte dvěma osobám.
     * Psa první osoby nechte zestárnout o 1 rok a psa druhé osoby nechte také zestárnout o 1 rok.
     *
     * Nakonec vypište věk psa libovolné osoby, který bude o 2 roky vyšší, než věk na začátku programu.
     * Ověříte si tak, že mají obě osoby opravdu referenci na jednoho a toho samého psa.
     */
    public class Cviceni7 : Cviceni {
        
        public void Run() {
            Osoba karel = new Osoba("Karel");
            Osoba lenka = new Osoba("Lenka");
            Pes azor = new Pes("Azor");
            karel.PridatPsa(azor);
            lenka.PridatPsa(azor);
            karel.VratPsa().Zestarni();
            Console.WriteLine(azor);
            lenka.VratPsa().Zestarni(2);
            Console.WriteLine(azor);
        }
    }
    
    class Pes
    {
        private string jmeno;
        private byte vek;

        public Pes(string jmeno) {
            this.jmeno = jmeno;
        }

        public void Zestarni() {
            Zestarni(1);
        }

        public void Zestarni(byte roky) {
            vek += roky;
        }

        public override string ToString() {
            return string.Format("{0} ({1} let)", jmeno, vek);
        }
    }
    
    class Osoba
    {
        private string jmeno;
        private Pes pes;

        public Osoba(string jmeno) {
            this.jmeno = jmeno;
        }

        public void PridatPsa(Pes pes) {
            this.pes = pes;
        }

        public bool MaPsa() {
            return pes != null;
        }

        public Pes VratPsa() {
            return pes;
        }
    }
}