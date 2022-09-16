using Mini_project_Asset_tracking.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_project_Asset_tracking
{
    // These are methods invoked as menu actions (by links in menu items)
    static class ActionMethods
    {
        public static bool exit = false;        // Signal to exit program main loop
        static int lowerPartOfScreen = 8;       // Where to list assets on screen

        // List assets on screen
        public static void listAssets()
        {
            // Clear lower part of screen
            ConsoleScreen.clearLowerPart(lowerPartOfScreen);

            // Print higlighted header
            ConsoleScreen.highLight();
            Console.WriteLine("Name".PadRight(10) + "Model".PadRight(10) + "Price".PadLeft(7)
                + "   " + "Purchased".PadRight(12) + "End-of-Life".PadRight(12)
                + "Type".PadRight(10) + "Brand".PadRight(10));
            ConsoleScreen.setAlertColor();

            // Print list of assets
            foreach (Asset a in AssetLists.Assets) a.Display();
        }

        // Add new assets to list by user input
        public static void addAssets()
        {
            char ok = '-';      // User input
            Asset newAsset = new Asset(new DateTime(), new DateTime(), 0, "-model-", "-name-", "-type-", "-Brand-");

            // Where to display the new asset template as it is built
            int displayAtRow = lowerPartOfScreen - 2;
            newAsset.Display(displayAtRow);

            // Clear screen below for input dialog
            ConsoleScreen.clearLowerPart(lowerPartOfScreen);

            // Display tempate asset as it is built
            Console.WriteLine("Add asset");

            // User input of Name, Model, Price, Purchase date, Type and Brand
            newAsset.Name = ConsoleScreen.readString("Name: ", "No input. Please try again: ");
            newAsset.Display(displayAtRow);
            newAsset.Model = ConsoleScreen.readString("Model: ", "No input. Please try again: ");
            newAsset.Display(displayAtRow);
            newAsset.Price = ConsoleScreen.readInt("Price ($): ", "Not a number. Please try again: ");
            newAsset.Display(displayAtRow);
            newAsset.PurchaseDate = ConsoleScreen.readDate("Purchase date: ", "Not a date. Please try again: ");
            newAsset.Display(displayAtRow);
            newAsset.Type = ConsoleScreen.readStringFromList("Type: ", "Not a Type. Please try again: ", AssetLists.Types);
            newAsset.Display(displayAtRow);
            newAsset.Brand = ConsoleScreen.readStringFromList("Brand: ", "Not a Brand. Please try again: ", AssetLists.Brands);
            newAsset.Display(displayAtRow);

            // Calculate End-of-Life (three years after Purchase)
            newAsset.EndOfLife = newAsset.PurchaseDate.AddYears(3);
            newAsset.Display(displayAtRow);

            // Confirm by user
            Console.Write("Add new asset to list (y/n): ");
            while(ok == '-')
            {
                ok = Console.ReadKey().KeyChar;
                switch (ok)
                {
                    case 'y':
                        AssetLists.Assets.Add(newAsset);
                        break;
                    case 'n':
                        break;
                    default:
                        Console.CursorLeft = 0;
                        Console.Write("Pleas answer 'y' or 'n': ");
                        ok = '-';
                        break;
                }
            }
        }

        // Delete an asset by user choise
        public static void deleteAsset()
        {
            // int Row = 0;    // User input row on screen
            // int Col = 0;    // Input column
            int i = 0;      // Index
            char c = ' ';   // User input choise

            // Clear screen, save cursor and list assets
            Console.Clear();
            ConsoleScreen.saveCur();
            listAssets();

            // At top of screen, ask for user choise
            ConsoleScreen.restoreCur();
            Console.WriteLine("Delete asset");
            Console.Write("Choose asset (n=next, p=previous, d=delete, q=quit): ");
            ConsoleScreen.saveCur();
            //Row = Console.CursorTop;
            //Col = Console.CursorLeft;

            // Display which asset is in focus below user input
            AssetLists.Assets[i].Display(3);

            // Input user choise (exit on 'q')
            ConsoleScreen.restoreCur();
            while ((c = Console.ReadKey().KeyChar) != 'q')
            {
                switch (c)
                {
                    case 'n':
                        // Next: Switch asset in focus (down), if not at end-of-list
                        if (i < AssetLists.Assets.Count - 1) i++;
                        break;
                    case 'p':
                        // Previous: Switch asset in focus (up), if not at start-of-list
                        if (i > 0) i--;
                        break;
                    case 'd':
                        // Delete: Remove the asset in focus from the list
                        AssetLists.Assets.RemoveAt(i);
                        // If it was the last asset in the list, update to the now last item
                        if (i > AssetLists.Assets.Count - 1) i = AssetLists.Assets.Count - 1;
                        // Update the list of assets on screen below
                        listAssets();
                        break;
                    default:
                        // Any other input
                        Console.Write("Faulty input");
                        break;
                }

                // If list is now empty: Exit
                if (AssetLists.Assets.Count == 0) break;

                // Display the asset now in focus
                AssetLists.Assets[i].Display(3);

                // Restore cursor to input point and erase rest of row
                ConsoleScreen.restoreCur();
                Console.Write(" ".PadRight(Console.WindowWidth));
                ConsoleScreen.restoreCur();
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
            AssetLists.Assets = AssetLists.Assets.OrderBy(x => x.Price).ThenBy(x => x.PurchaseDate).ToList();
        }

        public static void sortAssetsByName()
        {
            Console.WriteLine("In sortAssetsByName");
            AssetLists.Assets = AssetLists.Assets.OrderBy(x => x.Name).ThenBy(x => x.PurchaseDate).ToList();
        }
        public static void sortAssetsByModel()
        {
            Console.WriteLine("In sortAssetsByModel");
            AssetLists.Assets = AssetLists.Assets.OrderBy(x => x.Model).ThenBy(x => x.PurchaseDate).ToList();
        }

        public static void sortAssetsByType()
        {
            Console.WriteLine("In sortAssetsByType");
            AssetLists.Assets = AssetLists.Assets.OrderBy(x => x.Type).ThenBy(x => x.PurchaseDate).ToList();
        }

        public static void sortAssetsByBrand()
        {
            Console.WriteLine("In sortAssetsByBrand");
            AssetLists.Assets = AssetLists.Assets.OrderBy(x => x.Brand).ThenBy(x => x.PurchaseDate).ToList();
        }

        public static void exitProgram()
        {
            ConsoleScreen.clearLowerPart(8);
            Console.WriteLine("Exit program method");
            exit = true;
        }
    }
}

// By Ole Victor