﻿using Mini_project_Asset_tracking.IO;
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
        public static List<string> Offices = new List<string> { "Malmö", "Copenhagen", "Stockholm", "New York", "Kalmar" };
    }
    public class Asset
    {
        public Asset(DateTime endOfLife, DateTime purchaseDate, 
            int price, string model, string name, string type, string brand)
        {
            EndOfLife = endOfLife;
            PurchaseDate = purchaseDate;
            Price = price;
            Model = model;
            Name = name;
            Type = type;
            Brand = brand;
        }

        public DateTime EndOfLife { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Price { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }

        public void Display(int row = 0)
        {
            if (row != 0)
            {
                ConsoleScreen.saveCur();
                ConsoleScreen.curSet(row);
            }
            if (Brand == null) Brand = "";
            Console.WriteLine(
                Name.PadRight(10) +
                Model.PadRight(10) +
                ("$" + Price).PadLeft(7) + "   " +
                PurchaseDate.ToString("d").PadRight(12) +
                Type.PadRight(10) +
                Brand.PadRight(10)
                );
            if(row != 0) ConsoleScreen.restoreCur();
        }
    }
}

// By Ole Victor