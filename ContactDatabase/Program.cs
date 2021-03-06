﻿
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace ContactDatabase {
    
    /**
     * Cílem projektu je vytvořit malou databázi kontaktů, kde bude uživatel moc ukládat svoje kontakty (jméno, příjmení, telefonní číslo)
     * a následně s jeho pomocí v této databázi fulltextově vyhledávat, položky do databáze přidávat, nebo mazat
     * Záměrem je zdigitalizovat klasický papírový adresář kontaktů a usnadnit tak práci zpracování a manipulaci s kontaktními údaji.
     */
   
    internal class Program {
   
        public static List<Contact> contacts = new List<Contact>();
        
        public static StreamWriter streamWriter;
        
        public static string filePath = "contacts.txt";
        
        /**
         * Main method
         *
         * @return void
         */
        
        public static void Main(string[] args) {

            initializeDatabase();
            
            // Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Dobrý den,\nvítejte v databázi kontaktů. Zde si můžete ukládat, prohlížet a vyhledávat kontakty.\n");

            var menuItems = new ArrayList();
            
            menuItems.Add("Seznam všech kontaktů");
            menuItems.Add("Vytvoření nového kontaktu");
            menuItems.Add("Vyhledávání v kontaktech");
            menuItems.Add("Konec");
            
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
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            
            Console.WriteLine("MENU");
            Console.WriteLine("----------------");

            Console.ResetColor();
            
            int i = 0;
            
            foreach(var menuItem in menuItems) {
                
                Console.WriteLine((++i) + ". " + menuItem);
            }
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Vyberte položku s pomocí klávesnice (podle číselného označení): ");
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
                    
                    case 4:

                        Console.WriteLine("Nashledanou!");
                        
                        return;
                        
                        // Konec :-)

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
            
            Console.Clear();
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Vypisuji seznam kontaktů.\n");
            Console.ResetColor();

            if(contacts.Count > 0) {            
            
                foreach (Contact contact in contacts) {
                    
                    Console.WriteLine(contact.fullname + " | T: " + contact.phone + " | E: " + contact.email);
                }
                
            } else {
                
                Console.WriteLine("Seznam kontaktů je bohužel zatím prázdný...");
            }
        }
        
        /**
         * CreateNewContact
         * --------------
         * Vytvoření nového kontaktu podle vstupu z klávesnice
         */

        public static void CreateNewContact() {
          
            Console.Clear();
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Vybrali jste Vytvoření nového kontaktu.");
            Console.ResetColor();
            
            Console.Write("\nZadejte celé jméno: ");

            var fullname = Console.ReadLine();
            
            Console.Write("Zadejte telefoní číslo: ");
            
            var phone = Console.ReadLine();
            
            Console.Write("Zadejte e-mailovou adresu: ");

            var email = Console.ReadLine();

            string saveOrNot;
            
            do {

                 Console.Write("Chcete data uložit? (Ano|Ne):");
                
                 saveOrNot = Console.ReadLine();

            } while (saveOrNot != "Ano" && saveOrNot != "Ne");

            if (saveOrNot == "Ano") {

                contacts.Add(new Contact(fullname, phone, email));
                
                UpdateData();
                
                Console.Clear();
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Kontakt byl úspěšně uložen.\n");
            }

        }
        
        /**
         * SearchContact
         * --------------
         * Vyhledávání v seznamu kontaktů podle fulltextového vstupu
         */

        public static void SearchContact() {
            
            Console.WriteLine("Vybrali jste Vyhledávání kontaktů.");
        }
        
        /**
         * Update data
         * ----------
         */

        private static void UpdateData() {
            
            using (StreamWriter sw = new StreamWriter(filePath, true)) {
                    
                foreach (var contact in contacts) {
                
                    sw.WriteLine(contact.fullname + "|" + contact.phone + "|" + contact.email);
                }
                
                sw.Close();
            }
        }
        
        /**
         * Initialize database
         * -------------------
         */

        private static void initializeDatabase() {
            
            using (StreamWriter sw = new StreamWriter(filePath, true)) {
                
                sw.Close();
                
                string[] lines = System.IO.File.ReadAllLines(filePath);
                
                foreach (string contact in lines) {
                    
                    string[] parts = contact.Split('|');
                    
                    contacts.Add(new Contact(parts[0], parts[1], parts[2]));
                }
            }
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

    class Contact {

        public string fullname;

        public string phone;

        public string email;

        public Contact(string fullname, string phone, string email) {

            this.fullname = fullname;
            this.phone = phone;
            this.email = email;
        }

    }
}
    