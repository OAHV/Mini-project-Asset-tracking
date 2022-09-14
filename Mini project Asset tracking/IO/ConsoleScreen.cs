using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Mini_project_Asset_tracking.IO
{
    public static class ConsoleScreen
    {
        // Default values
        static int errorRow = 0;
        static int errorCol = 0;
        static int errorLenth = 40;
        static int savedRow = 0;
        static int savedCol = 0;

        // Cursor and color control
        public static void curSet(int row = 0, int col = 0)
        {
            Console.CursorTop = row;
            Console.CursorLeft = col;
        }

        public static void saveCur()
        {
            savedRow = Console.CursorTop;
            savedCol = Console.CursorLeft;
        }

        public static void restoreCur()
        {
            Console.CursorTop = savedRow;
            Console.CursorLeft = savedCol;
        }

        public static void setColor(bool alert = false)
        {
            if (alert)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Red;
            }
            else Console.ResetColor();
        }

        public static void highLight()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
        }

        // Error messaging
        public static void errorDisplay(string message)
        {
            // Set position and color - write message
            curSet(errorRow, errorCol);
            setColor(true);
            Console.Write(message.PadRight(errorLenth));

            // Wait for key pressed - erase message
            while (!Console.KeyAvailable) ;
            curSet(errorRow, errorCol);
            setColor(false);
            Console.Write(" ".PadRight(errorLenth));
        }

        // Erase rows from given row and down the screen
        public static void eraseLowerPart(int fromRow)
        {
            int lastRow = Console.WindowHeight - fromRow - 1;
            Console.CursorTop = fromRow;
            Console.CursorLeft = 0;
            for (int r = 0; r < lastRow; r++) Console.WriteLine(" ".PadRight(Console.WindowWidth - Console.CursorLeft));
            Console.CursorTop = fromRow;
        }

        // User input methods with error and validity control
        public static string readString(string prompt, string errorMessage)
        {
            string inputBuffer = "";
            Console.Write(prompt);
            while ((inputBuffer = Console.ReadLine()) == "")
            {
                Console.Write(errorMessage);
            }
            return inputBuffer;
        }

        public static DateTime readDate(string prompt, string errorMessage)
        {
            string inputBuffer = "";
            DateTime inputDate = new DateTime();
            Console.Write(prompt);
            while (inputBuffer == "")
            {
                inputBuffer = Console.ReadLine();
                try
                {
                    inputDate = Convert.ToDateTime(inputBuffer);
                }
                catch
                {
                    Console.Write(errorMessage);
                    inputBuffer = "";
                    continue;
                }
            }
            return inputDate;
        }

        public static int readInt(string prompt, string errorMessage)
        {
            string inputBuffer = "";
            int inputInt = 0;
            Console.Write(prompt);
            while (inputBuffer == "")
            {
                inputBuffer = Console.ReadLine();
                try
                {
                    inputInt = Convert.ToInt32(inputBuffer);
                }
                catch
                {
                    Console.Write(errorMessage);
                    inputBuffer = "";
                    continue;
                }
                if (inputInt < 0)
                {
                    Console.Write(errorMessage);
                    inputBuffer = "";
                }
            }
            return inputInt;
        }

        public static string readStringFromList(string prompt, string errorMessage, List<string> list)
        {
            Console.Write(prompt);
            saveCur();
            string found = "";
            int matches = 0;
            string inputBuffer = "";
            eraseLowerPart(19);
            foreach (string str in list) Console.WriteLine(str);
            while(matches != 1)
            {
                matches = 0;
                restoreCur();
                inputBuffer += Console.ReadKey().KeyChar.ToString();
                saveCur();
                eraseLowerPart(19);
                foreach(string s in list)
                {
                    if (s.ToLower().Contains(inputBuffer.ToLower()))
                    {
                        matches++;
                        found = s;
                        Console.WriteLine(s + " : " + inputBuffer);
                    }
                }
                if(matches == 0)
                {
                    Console.WriteLine(errorMessage);
                    inputBuffer = "";
                }
            }
            restoreCur();
            Console.CursorLeft = 0;
            return found;
        }
    }
}

// By Ole Victor