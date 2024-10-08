using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_V2
{
    public class UIWindow
    {
        private int width;
        private int height;
        private int stringLength;

        private char[,] contents;

        /// <summary>
        /// Constructor method for a UIWindow object
        /// </summary>
        /// <param name="width">Width of the UI window</param>
        /// <param name="height">Height of the UI window</param>
        public UIWindow(int width, int height)
        {
            //set dimensions of window
            this.width = width;
            this.height = height;

            stringLength = width-2; //set maximum string length

            contents = new char[height, width];

            //top boundary
            contents[0, 0] = '┌';
            for (int i=1; i < width-1; i++)
            {
                contents[0, i] = '─';
            }
            contents[0,width-1] = '┐';

            //side boundaries
            for (int j=1; j < height -1; j++)
            {
                contents[j, 0] = '│';
                contents[j, width-1] = '│';
            }

            //bottom boundary
            contents[height -1, 0] = '└';
            for (int i = 1; i < width - 1; i++)
            {
                contents[height - 1, i] = '─';
            }
            contents[height - 1, width - 1] = '┘';
        }

        /// <summary>
        /// Method that prints the window to the console (Screen)
        /// </summary>
        /// <param name="startpos">The position on the console at which to start printing the window</param>
        public void printWindow(int[] startpos)
        {
            // Ensure startpos is within valid range
            int maxStartPosY = Console.BufferHeight - height;
            int maxStartPosX = Console.BufferWidth - width;

            int startY = Math.Max(0, Math.Min(startpos[0], maxStartPosY));
            int startX = Math.Max(0, Math.Min(startpos[1], maxStartPosX));

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int cursorLeft = startX + x;
                    int cursorTop = startY + y;

                    // Check if the cursor position is within the console buffer size
                    if (cursorLeft >= 0 && cursorLeft < Console.BufferWidth &&
                        cursorTop >= 0 && cursorTop < Console.BufferHeight)
                    {
                        Console.SetCursorPosition(cursorLeft, cursorTop);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(contents[y, x]);
                    }
                }
            }
        }

        /// <summary>
        /// Mutator method that adds a string to a line in the window
        /// </summary>
        /// <param name="linePos">The line at which to add the string</param>
        /// <param name="input">The string to add in to the window</param>
        public void AddLine(int linePos, string input)
        {
            //checks if line exists
            if (linePos <= 0 || linePos >= height-1)
            {
                return;
            }

            //checks if line is within character limit
            if (input.Length > stringLength)
            {
                return;
            }

            //clears the line for new message
            for (int i=0; i<stringLength; i++)
            {
                contents[linePos, 1 + i] = ' ';
            }

            //stores message in window
            for (int i=0; i<input.Length; i++)
            {
                contents[linePos, 1+i] = input[i];
            }
        }

        /// <summary>
        /// Mutator method which clears the window of its stored characters
        /// </summary>
        public void ClearContents()
        {
            for(int j=1; j<height-2; j++)
            {
                for (int i=1; i<width-2; i++)
                {
                    contents[j, i] = ' ';
                }
            }
        }

        /// <summary>
        /// Accessor Method that returns the height of the UI window
        /// </summary>
        /// <returns>The height of the UI window</returns>
        public int GetHeight()
        {
            return height;
        }

        /// <summary>
        /// Accessor Method that returns the width of the UI window
        /// </summary>
        /// <returns>The width of the UI window</returns>
        public int GetWidth()
        {
            return width;
        }
    }
}
