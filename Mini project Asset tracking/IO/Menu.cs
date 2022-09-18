using Mini_project_Asset_tracking.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_project_Asset_tracking
{
    public static class Menues
    {
        // Menues defined by lists of choises with actions attached

        // Create a sort menu
        public static Menu sortMenu = new Menu("Choises for sorting", "Sort by: ", new List<MenuItem> {
                new MenuItem("Sort by Office", 1, "1oO", ActionMethods.sortAssetsByOffice),
                new MenuItem("Sort by Price", 2, "2pP", ActionMethods.sortAssetsByPrice),
                new MenuItem("Sort by Date purchased", 3, "3pPdD", ActionMethods.sortAssetsByDate),
                new MenuItem("Sort by Date Name", 4, "4nN", ActionMethods.sortAssetsByName),
                new MenuItem("Sort by Date Model", 5, "5mM", ActionMethods.sortAssetsByModel),
                new MenuItem("Sort by Date Type", 6, "6tT", ActionMethods.sortAssetsByType),
                new MenuItem("Sort by Date Brand", 7, "7bB", ActionMethods.sortAssetsByBrand)
            });

        // Create a main menu
        // First a list of menu items (rows)
        static List<MenuItem> menuItems = new List<MenuItem>
        {
            new MenuItem("List assets", 1, "1lL", ActionMethods.listAssets),
            new MenuItem("Add assets", 2, "2aA", ActionMethods.addAssets),
            new MenuItem("Sort assets", 3, "3sS", ActionMethods.sortAssets),
            new MenuItem("Delete asset", 4, "4dD", ActionMethods.deleteAsset),
            new MenuItem("Quit", 5, "5qQ", ActionMethods.exitProgram)
        };

        // Add menu items to the main menu
        public static Menu mainMenu = new Menu("Main menu", "Your choise: ", menuItems);
    }

    public class Menu
    {
        // Cursor input row & column
        public int Row { get; set; }
        public int Col { get; set; }

        // Constructor
        public Menu(string title, string prompt, List<MenuItem> items)
        {
            Title = title;
            Prompt = prompt;
            Items = items;
        }

        string Title { get; set; }      // The title is displayed above the items
        string Prompt { get; set; }     // The promopt below items

        // The list of menu items
        List<MenuItem> Items { get; set; }

        // Method to display the menu on screen
        public void Display(int row = 0)
        {
            Console.Clear();
            Console.CursorTop = row;

            // Display the heading (title) highlighted
            CursorControl.highLight();
            Console.WriteLine(Title);
            CursorControl.setAlertColor();

            // Display all the menu items
            foreach (MenuItem item in Items) item.Display();

            // Display the prompt
            Console.Write(Prompt);

            // Save the cursor and display the list below the menu
            saveCur();
            ActionMethods.listAssets();
        }

        public void Input()
        {
            // Read user input (user menu choise)
            char inp = ' ';
            bool found = false;

            // Set cursor to input position - erase the rest of the row
            restoreCur();
            Console.Write(" ".PadRight(50));
            restoreCur();

            // Read input key
            inp = Console.ReadKey().KeyChar;
            foreach (MenuItem item in Items)
            {
                // Find a menu item that matches the key
                if (item.Choises.Contains(inp))
                {
                    // Found: Perform menu action and break out of loop
                    item.Perform();
                    found = true;
                    break;
                }
            }
            // If no valid input - Error message
            if (!found) ConsoleScreen.errorDisplay("Invalid input...");
        }

        // These two methods should be exchanged for the CursorControl methods
        public void saveCur()
        {
            Row = Console.CursorTop;
            Col = Console.CursorLeft;
        }

        public void restoreCur()
        {
            Console.CursorTop = Row;
            Console.CursorLeft = Col;

        }
    }

    public class MenuItem
    {
        // A menu item contains a title (text), a number, a string of valid key inputs
        // and a poiter to the action to perform when this item is choosen
        string Title { get; set; }
        public int Number { get; set; }
        public string Choises { get; set; }
        public Action MenuAction;

        // Constructor
        public MenuItem(string title, int number, string choises , Action menuAction)
        {
            Title = title;
            Number = number;
            Choises = choises;
            MenuAction = menuAction;
        }

        // Method for showing the menu item (the row) on screen
        public void Display()
        {
            Console.WriteLine($"{Number}. {Title} (\"{Choises}\")");
        }

        // Perform this menu action
        public void Perform()
        {
            MenuAction();
        }
   }
}

// By Ole Victor