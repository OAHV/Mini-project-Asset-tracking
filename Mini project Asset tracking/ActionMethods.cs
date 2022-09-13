using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_project_Asset_tracking
{
    static class ActionMethods
    {
        public static bool exit = false;
        public static void listAssets()
        {
            Console.CursorTop = 8;
            Console.WriteLine("Assets");
            foreach (Asset a in AssetLists.Assets) a.Display();
            return;
        }

        public static void addAssets()
        {
            Console.CursorTop = 8;
            Console.WriteLine("Add assets method\n\n\n\n\n\n");
            return;
        }
        public static void exitProgram()
        {
            Console.CursorTop = 8;
            Console.WriteLine("Exit program method\n\n\n\n\n\n");
            exit = true;
            return;
        }

    }
}

// By Ole Victor