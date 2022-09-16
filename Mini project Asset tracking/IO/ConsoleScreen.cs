using System;
using System.Collections;
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
        static int errorCol = 40;
        static int errorLenth = 20;
 
        // Cursor and color control
        public class CursorPos
        {
            public CursorPos(int row, int col)
            {
                Row = row;
                Col = col;
            }

            private int Row { get; set; }
            private int Col { get; set; }

            public void Set()
            {
                Console.CursorTop = Row;
                Console.CursorLeft = Col;
            }
        }

        static Stack<CursorPos> cursorStack = new Stack<CursorPos>();

        public static void PushCursor()
        {
            cursorStack.Push(new CursorPos(Console.CursorTop, Console.CursorLeft));
        }

        public static CursorPos PopCursor()
        {
            CursorPos cursorPos = cursorStack.Pop();
            cursorPos.Set();
            return cursorPos;
        }

        public static void curSet(int row = 0, int col = 0)
        {
            Console.CursorTop = row;
            Console.CursorLeft = col;
        }

        public static void saveCur()
        {
            PushCursor();
        }

        public static void restoreCur()
        {
            cursorStack.Peek().Set();
        }

        public static void setAlertColor(bool alert = false)
        {
            if (alert)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Red;
            }
            else Console.ResetColor();
        }

        public static void highLight(bool h = true)
        {
            if (h)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            } else Console.ResetColor();
        }

        // Error messaging
        public static void errorDisplay(string message)
        {
            PushCursor();
            // Set position and color - write message
            curSet(errorRow, errorCol);
            setAlertColor(true);
            Console.Write(message.PadRight(errorLenth));

            // Wait for key pressed - erase message
            while (!Console.KeyAvailable) ;
            curSet(errorRow, errorCol);
            setAlertColor(false);
            Console.Write(" ".PadRight(errorLenth));
            PopCursor();
        }

        // Erase rows from given row and down the screen
        public static void clearLowerPart(int fromRow)
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

        // User choise from a list of valid choises
        public static string readStringFromList(string prompt, string errorMessage, List<string> list)
        {
            string found = "";
            int matches = 0;
            string inputBuffer = "";

            // Promt for input (and save cursor position)
            Console.Write(prompt);
            saveCur();

            // Erase lower part of screen for showing choises
            clearLowerPart(19);
            foreach (string str in list) Console.WriteLine(str);

            // Until exactly one match from list of valid choises
            while(matches != 1)
            {
                matches = 0;

                // Restore cursor to input position
                restoreCur();

                // Read a user input character and add it to the unput buffer
                inputBuffer += Console.ReadKey().KeyChar.ToString();

                // Erase lower part of screen for showing now possible choises
                clearLowerPart(19);
                foreach(string s in list)
                {
                    // If a valid choise contains the now input buffer
                    if (s.ToLower().Contains(inputBuffer.ToLower()))
                    {
                        // Count it to matches
                        matches++;
                        // Save it as the current choise
                        found = s;
                        // Print it as a still valid choise
                        Console.WriteLine(s + " : " + inputBuffer);
                    }
                }

                // If no matches after looping through the list
                if(matches == 0)
                {
                    Console.WriteLine(errorMessage);
                    // Start again from scratch
                    inputBuffer = "";
                }
            }
            // Now we have found exactly one match
            PopCursor();
            Console.WriteLine("");

            // Return the found list item (string)
            return found;
        }
    }
}

// By Ole Victor