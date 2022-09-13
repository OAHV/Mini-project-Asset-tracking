using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_project_Asset_tracking
{
    public static class AssetLists
    {
        public static List<Asset> Assets = new List<Asset> {
            new Asset(Convert.ToDateTime("2023-11-11"), Convert.ToDateTime("2024-11-11"), 224, "iPhone", "14"  ),
            new Asset(Convert.ToDateTime("2023-11-11"), Convert.ToDateTime("2023-11-11"), 224, "iPhone", "13"  ),
            new Asset(Convert.ToDateTime("2023-11-11"), Convert.ToDateTime("2022-11-11"), 224, "iPhone", "12"  ),
            new Asset(Convert.ToDateTime("2023-11-11"), Convert.ToDateTime("2021-11-11"), 224, "iPhone", "11"  ),
            new Asset(Convert.ToDateTime("2023-11-11"), Convert.ToDateTime("2020-11-11"), 224, "iPhone", "10"  ),
            new Asset(Convert.ToDateTime("2023-11-11"), Convert.ToDateTime("2019-11-11"), 224, "iPhone", "9"  ),
            new Asset(Convert.ToDateTime("2023-11-11"), Convert.ToDateTime("2018-11-11"), 224, "iPhone", "8"  )
        };

        public static List<string> Types = new List<string> { "Phone", "Tablet", "Laptop", "Computer", "Server", "Coffee machine", "Sound system" };
        public static List<string> Brands = new List<string> { "Dell", "ASUS", "MacIntosh", "iPhone", "Samsung", "Xerox", "Bang Olufsen" };
        public static List<string> Offices = new List<string> { "Malmö", "Copenhagen", "Stockholm", "New York", "Kalmar" };
    }
    public class Asset
    {
        public Asset(DateTime endOfLife, DateTime purchaseDate, 
            int price, string model, string name)
        {
            EndOfLife = endOfLife;
            PurchaseDate = purchaseDate;
            Price = price;
            Model = model;
            Name = name;
        }

        DateTime EndOfLife { get; set; }
        DateTime PurchaseDate { get; set; }
        int Price { get; set; }
        string Model { get; set; }
        string Name { get; set; }
        enum Type { }

        public void Display()
        {
            Console.WriteLine($"{Name} ({Model}) ${Price} ({PurchaseDate.ToString("G")})");
        }
    }
}
