using System;

namespace CSharpCourse.Cviceni8 {
    
    /*
     * Naprogramujte jednoduchou textovou hru, která obsahuje následujících 7 propojených lokací:
     *
     * Každá lokace má název a textový popis, tato data budou následovat dále.
     * Každá lokace má také referenci na 4 okolní lokace (tedy na lokaci na severu, jihu, západě a východě).
     * Vytvořte herní svět z takto propojených lokací podle obrázku výše. Následně aplikaci naučte přijímat v cyklu příkazy od uživatele.
     * Příkazy jsou:
     *     jdi na [strana], např. "jdi na východ" - Jde na určitou světovou stranu
     *     konec - Ukončí aplikaci
     */
    public class Cviceni8 : Cviceni {
        
        public void Run() {
            Hra hra = new Hra();
            string prikaz = "";

            // Hlavní smyčka hry
            while (prikaz.ToLower() != "konec")
            {
                Console.WriteLine(hra.VratAktualniLokaci());
                Console.Write("Zadej příkaz: ");
                prikaz = Console.ReadLine();
                hra.ZpracujPrikaz(prikaz);
            }
        }
    }
    
    class Lokace
    {
        public Lokace sever;
        public Lokace jih;
        public Lokace zapad;
        public Lokace vychod;
        private string nazev;
        private string popis;
        
        public Lokace(string nazev, string popis)
        {
            this.nazev = nazev;
            this.popis = popis;
        }
        
        public override string ToString()
        {
            string vystup = nazev + "\n";
            vystup += popis + "\n\n";
            string smery = "";
            if (sever != null)
                smery += "sever ";
            if (jih != null)
                smery += "jih ";
            if (zapad != null)
                smery += "západ ";
            if (vychod != null)
                smery += "východ ";
            if (smery != null)
                vystup += "Můžeš jít na " + smery + "\n";
            return vystup;
        }
    }
    
    class Hra
    {
        private Lokace aktualniLokace;
        
        public Hra()
        {
            // Vytvoření lokací
            Lokace hrad = new Lokace("Hrad", "Stojíš před okovanou branou gotického hradu, která je zřejmě jediným vchodem do pevnosti. Klíčová dírka je pokryta pavučinami, což vzbuzuje dojem, že je budova opuštěná.");
            Lokace les1 = new Lokace("Les", "Jsi na lesní cestě, která se klikatí až za obzor, kde mizí v siluetě zapadajícího slunce. Ticho podvečerního lesa občas přeruší zpěv posledních ptáků.");
            Lokace les2 = new Lokace("Lesní rozcestí", "Nacházíš se na lesním rozcestí.");
            Lokace les3 = new Lokace("Les", "Jsi na lesní cestě, která se klikatí až za obzor, kde mizí v siluetě zapadajícího slunce. Ticho podvečerního lesa občas přeruší zpěv posledních ptáků.");
            Lokace rybnik = new Lokace("Rybník", "Došel jsi ke břehu malého rybníka. Hladina je v bezvětří jako zrcadlo. Kousek od tebe je dřevěná plošina se stavidlem.");
            Lokace les4 = new Lokace("Les", "Jsi na lesní cestě, která se klikatí až za obzor, kde mizí v siluetě zapadajícího slunce. Ticho podvečerního lesa občas přeruší zpěv posledních ptáků.");
            Lokace dum = new Lokace("Dům", "Stojíš před svým rodným domem, cítíš vůni čerstvě nasekaného dřeva, která se line z hromady vedle vstupních dveří.");
            // Propojení lokací
            hrad.vychod = les1;
            les1.zapad = hrad;
            les1.vychod = les2;
            les2.zapad = les1;
            les2.vychod = les3;
            les2.jih = les4;
            les3.zapad = les2;
            les3.vychod = rybnik;
            rybnik.zapad = les3;
            les4.sever = les2;
            les4.vychod = dum;
            dum.zapad = les4;
            // Uložení aktuální lokace
            aktualniLokace = dum;
        }
        
        public void ZpracujPrikaz(string prikaz)
        {
            prikaz = prikaz.ToLower();
            if (prikaz.StartsWith("jdi"))
            {
                if (prikaz.EndsWith("sever") && (aktualniLokace.sever != null))
                    aktualniLokace = aktualniLokace.sever;
                else if (prikaz.EndsWith("jih") && (aktualniLokace.jih != null))
                    aktualniLokace = aktualniLokace.jih;
                else if (prikaz.EndsWith("západ") && (aktualniLokace.zapad != null))
                    aktualniLokace = aktualniLokace.zapad;
                else if (prikaz.EndsWith("východ") && (aktualniLokace.vychod != null))
                    aktualniLokace = aktualniLokace.vychod;
                else 
                    Console.WriteLine("Tímto směrem nelze jít.");
            }
            else if (prikaz != "konec")
            {
                Console.WriteLine("Můj vstupní slovník neobsahuje tento příkaz.");
            }
        }
        
        public Lokace VratAktualniLokaci()
        {
            return aktualniLokace;
        }
    }
}