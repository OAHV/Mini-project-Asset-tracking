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
            Menu.eraseLowerPart(8);
            Console.WriteLine("Assets".PadRight(40));
            foreach (Asset a in AssetLists.Assets) a.Display();
            return;
        }

        public static void addAssets()
        {
            Menu.eraseLowerPart(8);
            Console.WriteLine("Add assets method");
            return;
        }
        public static void exitProgram()
        {
            Menu.eraseLowerPart(8);
            Console.WriteLine("Exit program method");
            exit = true;
            return;
        }

    }
}

// By Ole Victor