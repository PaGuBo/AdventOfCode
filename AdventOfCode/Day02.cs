using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.SleighPuzzles
{
    public class Day02
    {
        public static string SolveKeypad(List<string> input)
        {
            var sb = new StringBuilder();
            int[,] keypad = new[,] { {1,2,3},
                                     {4,5,6},
                                     {7,8,9 } };
            var row = 1;
            var col = 1;
            foreach(var line in input)
            {
                foreach(var dir in line)
                {
                    switch (dir)
                    {
                        case 'L':
                            if (col > 0) { col--; }
                            break;
                        case 'R':
                            if (col < 2) { col++; }
                            break;
                        case 'U':
                            if (row > 0) { row--; }
                            break;
                        case 'D':
                            if (row < 2) { row++; }
                            break;
                    }
                }
                sb.Append(keypad[row, col]);
            }
            return sb.ToString();
        }

        public static string SolveWeirdKeypad(List<string> input)
        {
            var sb = new StringBuilder();
            char[,] keypad = new[,] {   {' ', ' ', '1', ' ', ' '},
                                        {' ', '2', '3', '4', ' '},
                                        {'5', '6', '7', '8', '9'},
                                        {' ', 'A', 'B', 'C', ' '},
                                        {' ', ' ', 'D', ' ', ' '}};
            var row = 2;
            var col = 0;
            foreach (var line in input)
            {
                foreach (var dir in line)
                {
                    switch (dir)
                    {
                        case 'L':
                            if (col > 0 && keypad[row, col-1] != ' ') { col--; }
                            break;
                        case 'R':
                            if (col < 4 && keypad[row, col + 1] != ' ') { col++; }
                            break;
                        case 'U':
                            if (row > 0 && keypad[row - 1, col] != ' ') { row--; }
                            break;
                        case 'D':
                            if (row < 4 && keypad[row + 1, col] != ' ') { row++; }
                            break;
                    }
                }
                sb.Append(keypad[row, col]);
            }
            return sb.ToString();
        }
    }
}
