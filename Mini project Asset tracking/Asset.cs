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
        public static List<Asset> Assets = new List<Asset>();

        public static List<string> Types = new List<string> { "Phone", "Tablet", "Laptop", "Computer", "Server", "Coffee machine", "Sound system" };
        public static List<string> Brands = new List<string> { "Dell", "ASUS", "MacIntosh", "iPhone", "Samsung", "Xerox", "Bang Olufsen" };
        public static List<string> Offices = new List<string> { "Malmö", "Copenhagen", "Stockholm", "New York", "Paris", "Berlin" };
    }
    public class Asset
    {
        public Asset(DateTime endOfLife, DateTime purchaseDate, 
            int price, string model, string name, string type, string brand, string kontor)
        {
            Name = name;
            Model = model;
            Type = type;
            Brand = brand;
            Kontor = kontor;
//            Kontor = Office.OfficeList[1];
//            Kontor = Office.OfficeList.Find(x => x.Name == kontor);
            EndOfLife = endOfLife;
            PurchaseDate = purchaseDate;
            Price = price;
        }

        public string Name { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Kontor { get; set; }  
//        public Office Kontor { get; set; }
        public DateTime EndOfLife { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Price { get; set; }

        public void Display(int row = 0)
        {
            // Special case: Single row print (not a list)
            if (row != 0)
            {
                CursorControl.PushCursor();
                CursorControl.curSet(row, 0);
            }


            //if(Kontor == null)
            //{
            //    Kontor = Office.OfficeList[0];
            //}
            // Print this asset on screen
            Console.Write(
                Name.PadRight(10) +
                Model.PadRight(10) +
                Type.PadRight(10) +
                Brand.PadRight(10) +
                Kontor.PadRight(11) +
                Office.OfficeList.Find(x => x.Name == Kontor).Country.PadRight(10) +
                //Kontor.Name.PadRight(10) +
                //Kontor.Country.PadRight(10) +
                (Office.OfficeList.Find(x => x.Name == Kontor).Currency.Symbol + " " +
                Office.OfficeList.Find(x => x.Name == Kontor).Currency.fromDollar(Price).ToString("0.00")).PadLeft(10) +
                ("$" + Price).PadLeft(10) +
                "   " +
                PurchaseDate.ToString("d").PadRight(12));

            if (EndOfLife < DateTime.Now.AddMonths(6)) Console.ForegroundColor = ConsoleColor.Yellow;
            if (EndOfLife < DateTime.Now.AddMonths(3)) Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(EndOfLife.ToString("d").PadRight(12));
            CursorControl.highLight(false);
            

            // Special case: Restore cursor row
            if (row != 0) CursorControl.PopCursor();
        }
    }
}

// By Ole Victor