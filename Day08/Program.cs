using System;
using System.IO;

namespace Day08
{
    class Program
    {
        private const string RECT = "rect ";
        private const string ROTATE_ROW = "rotate row y=";
        private const string ROTATE_COL = "rotate column x=";

        static void Main(string[] args)
        {
            //Console.ReadLine();
            Console.CursorVisible = false;
            //var input = File.ReadAllText(@"simple.txt").Replace("\r", "").Split('\n');
            //var input = File.ReadAllText(@"custom.txt").Replace("\r", "").Split('\n');
            //var input = File.ReadAllText(@"hard.txt").Replace("\r", "").Split('\n');
            var input = File.ReadAllText(@"reddit.txt").Replace("\r", "").Split('\n');
            var display = new char[6, 50];

            foreach(var line in input)
            {                
                if (line.Contains(RECT))
                {
                    var rectSize = line.Replace(RECT, "").Split('x');
                    var rectY = Convert.ToInt32(rectSize[0]);
                    var rectX = Convert.ToInt32(rectSize[1]);
                    for (int row = 0; row < rectX; row++)
                    {
                        for (int col = 0; col < rectY; col++)
                        {
                            display[row, col] = '#';
                        }
                    }
                    
                }
                else if(line.Contains(ROTATE_COL))
                {
                    var instr = line.Replace(ROTATE_COL, "").Replace(" by ", "x").Split('x');
                    var col = Convert.ToInt32(instr[0]);
                    var offset = Convert.ToInt32(instr[1]);
                    
                    for (int i = 0; i < offset; i++)
                    {
                        char temp = display[display.GetLength(0) - 1, col];
                        int j;
                        for (j = display.GetLength(0) - 1; j > 0 ; j--)
                        {
                            display[j, col] = display[j - 1, col];
                        }
                        display[j, col] = temp;
                        ShowDisplay(display);
                    }


                }
                else if (line.Contains(ROTATE_ROW))
                {
                    var instr = line.Replace(ROTATE_ROW, "").Replace(" by ", "x").Split('x');
                    var row = Convert.ToInt32(instr[0]);
                    var offset = Convert.ToInt32(instr[1]);

                    for (int i = 0; i < offset; i++)
                    {
                        char temp = display[row, display.GetLength(1) - 1];
                        int j;
                        for (j = display.GetLength(1) - 1; j > 0; j--)
                        {
                            display[row,j] = display[row,j - 1];
                        }
                        display[row,j] = temp;
                        ShowDisplay(display);
                    }
                }
                ShowDisplay(display);

            }

            Console.CursorVisible = true;
            Console.SetCursorPosition(0, 10);
            Console.ReadLine();
        }

        private static void ShowMessage(string message)
        {
            Console.SetCursorPosition(0,0);
            Console.WriteLine(message + "                                      ");
        }

        private static void ShowDisplay(char[,] display)
        {
            int pixelsLit = 0;
            for (int row = 0; row < display.GetLength(0); row++)
            {
                for (int col = 0; col < display.GetLength(1); col++)
                {
                    Console.SetCursorPosition(col, row + 3);
                    Console.Write(display[row, col]);
                    if (display[row, col] == '#')
                    {
                        pixelsLit++;
                    }
                }
            }
            Console.SetCursorPosition(0, display.GetLength(0) + 4);
            Console.Write($"Pixels lit: {pixelsLit}");
        }
    }
}
