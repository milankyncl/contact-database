
using System;
using System.Collections;

namespace ContactDatabase {
    
    /**
     * Cílem projektu je vytvořit malou databázi kontaktů, kde bude uživatel moc ukládat svoje kontakty (jméno, příjmení, telefonní číslo)
     * a následně s jeho pomocí v této databázi fulltextově vyhledávat, položky do databáze přidávat, nebo mazat
     * Záměrem je zdigitalizovat klasický papírový adresář kontaktů a usnadnit tak práci zpracování a manipulaci s kontaktními údaji.
     */

    internal class Program {
        
        /**
         * Main method
         *
         * @return void
         */
        
        public static void Main(string[] args) {
            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Dobrý den,\nvítejte v databázi kontaktů. Zde si můžete ukládat, prohlížet a vyhledávat kontakty.\n");

            var menuItems = new ArrayList();
            
            menuItems.Add("Seznam všech kontaktů");
            menuItems.Add("Vytvoření nového kontaktu");
            menuItems.Add("Vyhledávání v kontaktech");
            
            Menu(menuItems);
        }
        
        /**
         * Menu method
         * -----------
         * Vykreslí menu a čeká na vstup klávesnice
         *
         * @return void
         */

        public static void Menu(ArrayList menuItems) {
            
            Console.WriteLine("MENU");
            Console.WriteLine("----------------");

            Console.ResetColor();
            
            int i = 0;
            
            foreach(var menuItem in menuItems) {
                
                Console.WriteLine((++i) + ". " + menuItem);
            }
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Vyberte položku v pomocí klávesnice (podle číselného označení): ");
            Console.ResetColor();
            
            var parse = int.TryParse(Console.ReadLine(), out var item);
            
            Console.WriteLine("");
            
            if (parse && item > 0 && item < (menuItems.Count + 1)) {

                switch (item) {
                    
                    case 1:

                        ListContacts();

                        break;
                    
                    case 2:

                        CreateNewContact();

                        break;
                    
                    case 3:

                        SearchContact();

                        break;
                    
                }

            } else {
                
                Console.WriteLine("Zadejte číslo od 1 do " + menuItems.Count);
            }
            
            Console.WriteLine("");
            
            Menu(menuItems);
        }
        
        /**
         * ListContacts
         * --------------
         * Vypíše seznam kontaktů do konzole
         */

        public static void ListContacts() {
            
            Console.WriteLine("Vybrali jste Seznam kontaktů.");
        }
        
        /**
         * CreateNewContact
         * --------------
         * Vytvoření nového kontaktu podle vstupu z klávesnice
         */

        public static void CreateNewContact() {
            
            Console.WriteLine("Vybrali jste Vytvoření nového kontaktu.");
        }
        
        /**
         * SearchContact
         * --------------
         * Vyhledávání v seznamu kontaktů podle fulltextového vstupu
         */

        public static void SearchContact() {
            
            Console.WriteLine("Vybrali jste Vyhledávání kontaktů.");
        }
    }
    
    /**
     * OSOBNÍ POZNÁMKY K PŘEDMĚTU
     * ===================================================
     * 
     * Projekty:
     *
     * Šifry
     *     - Cesarova (posouvání písmen v abecedě)
     *     - Vigenerova (proházení abecedy)
     *     - klíč + Cesarova)
     *
     * Prvočísla:
     *     - zjistit která
     *     - zpracovat rozsah
     *
     * Třídění
     *     - seznam čísel podle velikosti
     *     - insert sort
     *     - select sort
     *     - merge sort
     *     - bubble sort
     *     - quick sort (dumb - pulici)
     *
     * Kalkulačka + paměť
     *
     * Text
     *     - analyza slov
     *     - analyza znaků (frekvenční analýza)
     *     - našeptávač slov
     *
     * Zvuk
     *     - přehrávač
     *     - piánko
     *
     * Databáze objektů
     *     - lidé
     *     - auta
     *     - zvířata
     *
     * 1. Odevzdání
     * ------------
     *
     * Popsat v komentáři, co bude program dělat a detailně vysvětlovat záměr
     *
     * První verze menu
     * 
     * ===================================================
     */

        
}
    