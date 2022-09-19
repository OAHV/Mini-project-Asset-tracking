using Mini_project_Asset_tracking.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_project_Asset_tracking
{
    public static class AssetLists
    {
        // All sorts of assets in lists
        public static List<Asset> Assets = new List<Asset>();

        // These lists are mainly used as input options
        // They could be implemented with their proper menues and files for saving
        public static List<string> Types = new List<string> { "Phone", "Tablet", "Laptop", "Computer", "Server", "Coffee machine", "Sound system" };
        public static List<string> Brands = new List<string> { "Dell", "ASUS", "MacIntosh", "HP", "iPhone", "Samsung", "Xerox", "Bang Olufsen" };
        public static List<string> Offices = new List<string> { "Malmö", "Copenhagen", "London", "New York", "Paris", "Berlin" };
    }
    public class Asset
    {
        // Constructor
        public Asset(DateTime endOfLife, DateTime purchaseDate, 
            int price, string model, string name, string type, string brand, string kontor)
        {
            Name = name;
            Model = model;
            Type = type;
            Brand = brand;
            Kontor = kontor;
//            Kontor = Office.OfficeList.Find(x => x.Name == kontor);   // It didn't work for me with nested JSON files...
            EndOfLife = endOfLife;
            PurchaseDate = purchaseDate;
            Price = price;
        }

        // Asset properties
        public string Name { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Kontor { get; set; }  
//        public Office Kontor { get; set; }        // Didn't work with nested JSON file
        public DateTime EndOfLife { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Price { get; set; }

        // Method for displaying an asset as a row on screen
        public void Display(int row = 0)
        {
            // Special case:
            // Single row print (not a list) at a specific row on screen
            if (row != 0)
            {
                CursorControl.PushCursor();
                CursorControl.curSet(row, 0);
            }

            // Print this asset on screen
            Console.Write(
                Name.PadRight(10) +         // Name
                Model.PadRight(10) +        // Model
                Type.PadRight(10) +         // Type
                Brand.PadRight(10) +        // Brand
                Kontor.PadRight(11) +       // Office
                // Country found by office
                Office.OfficeList.Find(x => x.Name == Kontor).Country.PadRight(10) +
                // Local currency found by office name
                (Office.OfficeList.Find(x => x.Name == Kontor).Currency.Symbol + " " +
                // Price in local currency found by office name
                Office.OfficeList.Find(x => x.Name == Kontor).Currency.fromDollar(Price).ToString("0.00")).PadLeft(10) +
                ("$" + Price).PadLeft(10) + // Price i dollars
                "   " +
                // Date of purchase
                PurchaseDate.ToString("d").PadRight(12));

            // Highlight End-of-Life date in yellow or red depending on date
            if (EndOfLife < DateTime.Now.AddMonths(6)) Console.ForegroundColor = ConsoleColor.Yellow;
            if (EndOfLife < DateTime.Now.AddMonths(3)) Console.ForegroundColor = ConsoleColor.Red;
            // Display date - reset color
            Console.WriteLine(EndOfLife.ToString("d").PadRight(12));
            CursorControl.highLight(false);

            // Special case: Restore cursor row
            if (row != 0) CursorControl.PopCursor();
        }
    }
}

// By Ole Victor