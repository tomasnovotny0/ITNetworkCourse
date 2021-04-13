using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CSharpCourse {
    class Program {
        static void Main(string[] args) {
            Cviceni3();
            return;
            
            Console.WriteLine("Zadej text:");
            string text = Console.ReadLine().ToLower();
            int pocetSamohlasek = 0;
            int pocetSouhlasek = 0;
            string samohlasky = "aeiouyáéěíóúůý";
            string souhlasky = "bcčdďfghjklmnpqrřsštťvwxzž";
            foreach (char c in text)
            {
                if (samohlasky.Contains(c.ToString()))
                    pocetSamohlasek++;
                else
                if (souhlasky.Contains(c.ToString()))
                    pocetSouhlasek++;
            }
            
            // ASCII
            char znak = 'a';
            int znakAscii = znak;
            
            // šifrování
            string s = "textkzasifrovani";
            Console.WriteLine("Původní text " + s);
            string sifrovane = "";
            int posun = 1;
            foreach (char c in s) {
                char novyZnak = (char) (c + posun);
                if (novyZnak > 'z') {
                    novyZnak = (char) (novyZnak - 26);
                }
                sifrovane += novyZnak;
            }

            Console.WriteLine("Šifrovaná zpráva je " + sifrovane);
        }

        /*
         * V minulém tutoriálu jsme si říkali o existenci ASCII tabulky.
         * Ta obsahuje vždy ASCII kód a příslušný znak, který se k němu váže, kódů je 255. Vypište tuto tabulku do konzole
         */
        static void Cviceni1() {
            Console.WriteLine("ASCII Tabulka");
            Console.WriteLine("=============");
            for (int i = 0; i < 256; i++) {
                Console.Write("{0}:{1}\t", i, (char) i);
            }
        }

        /*
         * Naprogramujte aplikaci, které zadáte na vstupu textový řetězec a ona zjistí, zda je to palindrom.
         * Palindrom je slovo, které se čte stejně zleva i zprava. Jsou to tedy např. slova: oko, anna, level, radar.
         */
        static void Cviceni2() {
            Console.WriteLine("Zadej palindrom:");
            string palindrom = Console.ReadLine();
            char[] array = palindrom.ToCharArray();
            Array.Reverse(array);
            string obracene = new string(array);
            if (palindrom.Equals(obracene)) {
                Console.WriteLine("Ano, toto je palindrom.");
            }
            else {
                Console.WriteLine("Toto není palindrom.");
            }
        }

        /*
         * Naprogramujte šifraci textu pomocí Vigenerovy šifry. Program si na vstupu vyžádá šifrované slovo a heslo.
         * Předpokládejme zadání slova "moribundus" a hesla "ahoj".
         * Program posune jednotlivá písmena v šifrovaném slovu o určitý počet znaků v abecedě dopředu.
         * Tento počet závisí na písmenech v heslu. V našem případě program posune první znak ve slovu o 1 ('a'), druhý o 8('h'),
         * třetí o 15('o'), čtvrtý o 10 ('j'), pátý zas o 1 ('a') a tak dále.
         *
         * Ve zjednodušené verzi nemusíte řešit, že heslo může být kratší než šifrované slovo a zadat ho jako "ahojahojah".
         * Nezapomeňte, že pokud je v heslu např. písmeno S a posun je 8, výsledný znak je opět A. Toto přetečení abecedy musíte ošetřit,
         * jinak získáte výsledek podobný tomuto: "nw?sc}}nv}", ale i ten značí, že jste na správné cestě.
         */
        static void Cviceni3() {
            Console.Write("Zadejte text k zašifrování: ");
            string zasifrovat = Console.ReadLine();
            Console.Write("Zadejte heslo: ");
            string heslo = Console.ReadLine();
            string sifra = "";
            for (int i = 0; i < zasifrovat.Length; i++) {
                int indexZnakuHesla = i % heslo.Length;
                char znakPosunu = heslo[indexZnakuHesla];
                int posun = znakPosunu < 'a' ? (znakPosunu - 'A') + 1 : (znakPosunu - 'a') + 1;
                char sifrovanyZnak = (char) (zasifrovat[i] + posun);
                if (sifrovanyZnak > 'z') {
                    sifrovanyZnak = (char) (sifrovanyZnak - 26);
                }
                sifra += sifrovanyZnak;
            }
            Console.WriteLine(sifra);
        }
    }
}