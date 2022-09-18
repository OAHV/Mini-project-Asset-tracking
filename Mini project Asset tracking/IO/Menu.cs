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
        // Create a sort menu
        public static Menu sortMenu = new Menu("Choises for sorting", "Sort by: ", new List<MenuItem> {
                new MenuItem("Sort by Price", 1, "1pP", ActionMethods.sortAssetsByPrice),
                new MenuItem("Sort by Date purchased", 2, "2pPdD", ActionMethods.sortAssetsByDate),
                new MenuItem("Sort by Date Name", 3, "3nN", ActionMethods.sortAssetsByName),
                new MenuItem("Sort by Date Model", 4, "4mM", ActionMethods.sortAssetsByModel),
                new MenuItem("Sort by Date Type", 5, "5tT", ActionMethods.sortAssetsByType),
                new MenuItem("Sort by Date Brand", 6, "6bB", ActionMethods.sortAssetsByBrand)
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

        // Add menu items to the main menu and display it on screen
        public static Menu mainMenu = new Menu("Main menu", "Your choise: ", menuItems);
    }

    public class Menu
    {
        // Cursor input row & column
        public int Row { get; set; }
        public int Col { get; set; }
        public Menu(string title, string prompt, List<MenuItem> items)
        {
            Title = title;
            Prompt = prompt;
            Items = items;
        }

        string Title { get; set; }
        string Prompt { get; set; }
        List<MenuItem> Items { get; set; }

        public void Display(int row = 0)
        {
            Console.Clear();
            Console.CursorTop = row;
            CursorControl.highLight();
            Console.WriteLine(Title);
            CursorControl.setAlertColor();
            foreach (MenuItem item in Items) item.Display();
            Console.Write(Prompt);
            saveCur();
            ActionMethods.listAssets();
        }

        public void Input()
        {
            char inp = ' ';
            bool found = false;
            restoreCur();
            Console.Write(" ".PadRight(50));
            restoreCur();
            inp = Console.ReadKey().KeyChar;
            foreach (MenuItem item in Items)
            {
                if (item.Choises.Contains(inp))
                {
                    item.Perform();
                    found = true;
                    break;
                }
            }
            if (!found) ConsoleScreen.errorDisplay("Invalid input...");
        }

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
        string Title { get; set; }
        public int Number { get; set; }
        public string Choises { get; set; }
        public Action MenuAction;

        public MenuItem(string title, int number, string choises , Action menuAction)
        {
            Title = title;
            Number = number;
            Choises = choises;
            MenuAction = menuAction;
        }

        public void Display()
        {
            Console.WriteLine($"{Number}. {Title} (\"{Choises}\")");
        }

        public void Perform()
        {
            MenuAction();
        }
   }
}

// By Ole Victor