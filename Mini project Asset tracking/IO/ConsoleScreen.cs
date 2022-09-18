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
        // Default values for error messages
        static int errorRow = 0;        // Row
        static int errorCol = 40;       // Column
        static int errorLenth = 40;     // Length
 
        // Cursor and color control

        // Class that keeps track of cursor positions
        public class CursorPos
        {
            // Constructor
            public CursorPos(int row, int col)
            {
                Row = row;
                Col = col;
            }

            private int Row { get; set; }
            private int Col { get; set; }

            // Set the screen cursor position to this object's values
            public void Set()
            {
                Console.CursorTop = Row;
                Console.CursorLeft = Col;
            }
        }

        // A stack of cursor positions to push, pop and read from
        static Stack<CursorPos> cursorStack = new Stack<CursorPos>();

        // Save the current screen cursor position to the stack
        public static void PushCursor()
        {
            cursorStack.Push(new CursorPos(Console.CursorTop, Console.CursorLeft));
        }

        // Set the screen cursor position to the top stack values and pop it
        public static CursorPos PopCursor()
        {
            CursorPos cursorPos = cursorStack.Pop();
            cursorPos.Set();
            return cursorPos;
        }

        // Set the screen cursor position (no stack involvement)
        public static void curSet(int row = 0, int col = 0)
        {
            Console.CursorTop = row;
            Console.CursorLeft = col;
        }

        // Set screen cursor position to stack top values (no pop)
        public static void restoreCur()
        {
            cursorStack.Peek().Set();
        }

        // Set text colors to alert (warning) for error messages etc
        public static void setAlertColor(bool alert = false)
        {
            if (alert)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Red;
            }
            else Console.ResetColor();
        }

        // Set text colors to highligh for headings etc
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
            // Calculate window last row depending on window hieght
            int lastRow = Console.WindowHeight - fromRow - 1;

            // Erase from top to bottom
            Console.CursorTop = fromRow;
            Console.CursorLeft = 0;
            for (int r = 0; r < lastRow; r++) Console.WriteLine(" ".PadRight(Console.WindowWidth - Console.CursorLeft));

            // Set cursor at top of area
            Console.CursorTop = fromRow;
        }

        // User input methods with error and validity control
        public static string readString(string prompt, string errorMessage)
        {
            string inputBuffer = "";        // Empty string buffer
            Console.Write(prompt);          // Print input prompt
            PushCursor();     // Save cursor to stack
            // Read user input until valid
            while ((inputBuffer = Console.ReadLine()) == "")
            {
                errorDisplay(errorMessage);
                restoreCur(); // Set cursor position back
            }
            // Restor previous cursor position
            ConsoleScreen.PopCursor();
            // Write extra linefeed
            Console.WriteLine("");

            // Return the user input string
            return inputBuffer;
        }

        public static DateTime readDate(string prompt, string errorMessage)
        {
            string inputBuffer = "";
            DateTime inputDate = new DateTime();
            Console.Write(prompt);
            ConsoleScreen.PushCursor();
            while (inputBuffer == "")
            {
                inputBuffer = Console.ReadLine();
                try
                {
                    inputDate = Convert.ToDateTime(inputBuffer);
                }
                catch
                {
                    ConsoleScreen.errorDisplay(errorMessage);
                    ConsoleScreen.restoreCur();
                    inputBuffer = "";
                    continue;
                }
            }
            ConsoleScreen.PopCursor();
            Console.WriteLine("");
            return inputDate;
        }

        public static int readInt(string prompt, string errorMessage)
        {
            string inputBuffer = "";
            int inputInt = 0;
            Console.Write(prompt);
            ConsoleScreen.PushCursor();
            while (inputBuffer == "")
            {
                inputBuffer = Console.ReadLine();
                try
                {
                    inputInt = Convert.ToInt32(inputBuffer);
                }
                catch
                {
                    ConsoleScreen.errorDisplay(errorMessage);
                    ConsoleScreen.restoreCur();
                    inputBuffer = "";
                    continue;
                }
                if (inputInt < 0)
                {
                    ConsoleScreen.errorDisplay(errorMessage);
                    ConsoleScreen.restoreCur();
                    inputBuffer = "";
                }
            }
            ConsoleScreen.PopCursor();
            Console.WriteLine("");
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
            PushCursor();

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
                    ConsoleScreen.errorDisplay(errorMessage);
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