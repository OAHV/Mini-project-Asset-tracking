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
            foreach (Asset a in AssetLists.Assets) a.Display();
            Console.WriteLine("List assets method");
            return;
        }

        public static void addAssets()
        {
            Console.WriteLine("Add assets method");
            return;
        }
        public static void exitProgram()
        {
            Console.WriteLine("Exit program method");
            exit = true;
            return;
        }

    }
}
