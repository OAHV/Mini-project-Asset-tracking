using Mini_project_Asset_tracking.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_project_Asset_tracking
{
    static class ActionMethods
    {
        static int sortBy = 0;
        public static bool exit = false;
        public static void listAssets()
        {
            ConsoleScreen.eraseLowerPart(8);
            ConsoleScreen.highLight();
            Console.WriteLine("Name".PadRight(10) + "Model".PadRight(10) + "Price".PadLeft(7) + "   Purchased".PadRight(15) + "Type".PadRight(10) + "Brand".PadRight(10));
            ConsoleScreen.setColor();
            foreach (Asset a in AssetLists.Assets) a.Display();
        }

        public static void addAssets()
        {
            int dRow = 7;
            ConsoleScreen.eraseLowerPart(dRow+1);
            Console.WriteLine("Add asset");
            Asset newAsset = new Asset(new DateTime(), new DateTime(), 0, "-model-", "-name-", "-type-", "-Brand-");
            newAsset.Display(dRow);
            newAsset.Name = ConsoleScreen.readString("Name: ", "No input. Please try again: ");
            newAsset.Display(dRow);
            newAsset.Model = ConsoleScreen.readString("Model: ", "No input. Please try again: ");
            newAsset.Display(dRow);
            newAsset.Price = ConsoleScreen.readInt("Price ($): ", "Not a number. Please try again: ");
            newAsset.Display(dRow);
            newAsset.PurchaseDate = ConsoleScreen.readDate("Purchase date: ", "Not a date. Please try again: ");
            newAsset.Display(dRow);
            newAsset.EndOfLife = ConsoleScreen.readDate("End-of-life date: ", "Not a date. Please try again: ");
            newAsset.Display(dRow);
            newAsset.Type = ConsoleScreen.readStringFromList("Type: ", "Not a Type. Please try again: ", AssetLists.Types);
            newAsset.Display(dRow);
            newAsset.Brand = ConsoleScreen.readStringFromList("Brand: ", "Not a Brand. Please try again: ", AssetLists.Brands);
            newAsset.Display(dRow);

            AssetLists.Assets.Add(newAsset);
        }

        public static void deleteAsset()
        {
            int Row = 0;
            int Col = 0;
            int i = 0;
            char c = ' ';
            Console.Clear();
            ConsoleScreen.saveCur();
            listAssets();
            ConsoleScreen.restoreCur();
            Console.WriteLine("Delete asset");
            Console.Write("Choose asset (n=next, p=previous, d=delete, q=quit): ");
            Row = Console.CursorTop;
            Col = Console.CursorLeft;
            AssetLists.Assets[i].Display(3);
            while ((c = Console.ReadKey().KeyChar) != 'q')
            {
                switch (c)
                {
                    case 'n':
                        if(i<AssetLists.Assets.Count-1)  i++;
                        break;
                    case 'p':
                        if(i>0)i--;
                        break;
                    case 'd':
                        AssetLists.Assets.RemoveAt(i);
                        if (i > AssetLists.Assets.Count - 1) i = AssetLists.Assets.Count - 1;
                        listAssets();
                        break;
                    default:
                        Console.WriteLine("Faulty input");
                        continue;
                        break;
                }
                if (i < 0) i = 0;
                if (AssetLists.Assets.Count == 0) break;
                AssetLists.Assets[i].Display(3);
                Console.CursorTop = Row;
                Console.CursorLeft = Col;
            }
            

        }

        public static void sortAssets()
        {
            Console.Clear();
            ConsoleScreen.saveCur();
            listAssets();
            ConsoleScreen.restoreCur();
            Menues.sortMenu.Display();
            Menues.sortMenu.Input();
        }

        public static void sortAssetsByDate()
        {
            Console.WriteLine("In sortAssetsByDate");
            AssetLists.Assets = AssetLists.Assets.OrderBy(x => x.PurchaseDate).ToList();
        }

        public static void sortAssetsByPrice()
        {
            Console.WriteLine("In sortAssetsByPrice");
            AssetLists.Assets = AssetLists.Assets.OrderBy(x => x.Price).ToList();
        }

        public static void sortAssetsByName()
        {
            Console.WriteLine("In sortAssetsByName");
            AssetLists.Assets = AssetLists.Assets.OrderBy(x => x.Name).ToList();
        }
        public static void sortAssetsByModel()
        {
            Console.WriteLine("In sortAssetsByModel");
            AssetLists.Assets = AssetLists.Assets.OrderBy(x => x.Model).ToList();
        }

        public static void sortAssetsByType()
        {
            Console.WriteLine("In sortAssetsByType");
            AssetLists.Assets = AssetLists.Assets.OrderBy(x => x.Type).ToList();
        }

        public static void sortAssetsByBrand()
        {
            Console.WriteLine("In sortAssetsByBrand");
            AssetLists.Assets = AssetLists.Assets.OrderBy(x => x.Brand).ToList();
        }

        public static void exitProgram()
        {
            ConsoleScreen.eraseLowerPart(8);
            Console.WriteLine("Exit program method");
            exit = true;
            return;
        }
    }
}

// By Ole Victor