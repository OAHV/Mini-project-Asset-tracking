using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_project_Asset_tracking
{
    internal class Menu
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

        public void Display()
        {
            Console.WriteLine(Title);
            foreach (MenuItem item in Items) item.Display();
            Console.Write(Prompt);
            saveCur();
        }

        public void Input()
        {
            bool found = false;
            restoreCur();
            Console.Write(" ".PadRight(50));
            restoreCur();
            char inp = Console.ReadKey().KeyChar;
            foreach(MenuItem item in Items)
            {
                if (item.Choises.Contains(inp)) 
                {
                    item.Perform();
                    found = true;
                    break;
                }
            }
            if(!found) Console.WriteLine("Invalid input...\n\n\n\n\n\n");
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

        public static void eraseLowerPart(int fromRow)
        {
            Console.CursorTop = fromRow;
            for (int r = 0; r < Console.WindowHeight - fromRow - 1; r++) Console.WriteLine(" ".PadRight(60));
            Console.CursorTop = fromRow;
        }

    }

    internal class MenuItem
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