using System;
using System.Linq;

namespace CSharpCourse {
    class Program {
        static void Main(string[] args) {
            Cviceni6();
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
            string str = "textkzasifrovani";
            Console.WriteLine("Původní text " + str);
            string sifrovane = "";
            int posun = 1;
            foreach (char c in str) {
                char novyZnak = (char) (c + posun);
                if (novyZnak > 'z') {
                    novyZnak = (char) (novyZnak - 26);
                }
                sifrovane += novyZnak;
            }

            Console.WriteLine("Šifrovaná zpráva je " + sifrovane);
            
            // užitečné metody pro string
            // Insert(index, text)
            // Remove(index1, ? index2)
            // Substring()
            // CompareTo()
            // Split(), Join()
            
            // Dekodér morseovky
            // řetězec, který chceme dekódovat
            string s = ".. - -. . - .-- --- .-. -.-";
            Console.WriteLine("Původní zpráva: {0}", s);
            // řetězec s dekódovanou zprávou
            string zprava = "";

            // vzorová pole
            string abecedniZnaky = "abcdefghijklmnopqrstuvwxyz";
            string[] morseovyZnaky = {".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....",
                "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-",
                "...-", ".--", "-..-", "-.--", "--.."};
            // dekódování
            string[] znaky = s.Split(' ');
            foreach (string znakMorseovky in znaky) {
                char abecedniZnak = '?';
                int idx = Array.IndexOf(morseovyZnaky, znakMorseovky);
                if (idx >= 0)
                    abecedniZnak = abecedniZnaky[idx];
                zprava += abecedniZnak;
            }

            Console.WriteLine("Dekódovaná zpráva: {0}", zprava);
            
            // Escape sekvence
            // \n - odřádkování
            // \t - tabulátor
            // automatické escapování řetězce - @"text\text"
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

        /*
         * Naprogramujte aplikaci, která vypočítá průměr ze zadaných známek.
         * Vstup uživatel zadá jako jeden textový řetězec, kde jsou jednotlivé známky oddělené čárkou. Průměr by měl být desetinné číslo.
         */
        static void Cviceni4() {
            Console.WriteLine("Výpočet průměru známek");
            Console.WriteLine("Zadejte známky oddělené čárkou:");
            string[] znamky = Console.ReadLine().Split(',');
            int soucet = 0;
            foreach (string znamka in znamky) {
                int hodnota = int.Parse(znamka);
                soucet += hodnota;
            }
            double prumer = soucet / (double) znamky.Length;
            Console.WriteLine("Průměr: {0}", prumer);
        }

        /*
         * Naprogramujte převaděč zadaného textu do morzeovy abecedy, tedy opačný příklad k tomu, který byl v článku.
         * Speciální znaky a diakritiku zanedbejte (vynechte je - ve výpisu se nezobrazí místo nich nic).
         */
        static void Cviceni5() {
            Console.WriteLine("Zadejte zprávu k zakódování:");
            string text = Console.ReadLine().ToLower();
            string abecedniZnaky = "abcdefghijklmnopqrstuvwxyz";
            string[] morseovyZnaky = {".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....",
                "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-",
                "...-", ".--", "-..-", "-.--", "--.."};
            string sifrovane = "";
            foreach (char znak in text) {
                int index = abecedniZnaky.IndexOf(znak);
                if(index < 0)
                    continue;
                string morse = morseovyZnaky[index];
                sifrovane += morse + " ";
            }

            Console.WriteLine("Zakódovaná zpráva: " + sifrovane);
        }

        /*
         * Naprogramujte rozveselovač textu. Aplikace funguje tak, že ji zadáte několik vět v jednom řetězci a ona za každou větu přidá smajlík.
         * Věta může končit buď tečkou, otazníkem nebo vykřičníkem. Pokud končí tečkou, bude smajlík umístěn místo ní.
         * Pokud ! nebo ?, bude umístěn za toto znaménko.
         * Smajlíci jsou postupně dosazovány v tomto pořadí:
         *     :) :D :P
         *
         * Čtvrtý smajlík v textu bude opět usměvavý, další rozesmátý a tak stále dokola.
         */
        static void Cviceni6() {
            Console.WriteLine("Zadej text k rozveselení:");
            char[] interpunkce = {'.', '?', '!'};
            string[] smajlici = {":)", ":D", ":P"};
            string text = Console.ReadLine();
            int index = 0;
            int indexSmajliku = 0;
            while (index < text.Length) {
                if (interpunkce.Contains(text[index])) {
                    if (text[index] == '.') {
                        text = text.Remove(index, 1);
                        --index;
                    }

                    text = text.Insert(index + 1, " " + smajlici[indexSmajliku++ % 3]);
                    ++index;
                }

                ++index;
            }
            Console.WriteLine("Rozveselený text: " + text);
        }
    }
}