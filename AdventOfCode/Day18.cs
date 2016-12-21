using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day18
    {
        private const char TRAP = '^';
        private const char SAFE = '.';
        public static int SafeTilesCount(string firstRow, int totalRows)
        {
            var rowMap = new Dictionary<string, string>();
            var safeTiles = 0;
            safeTiles += firstRow.Where(x => x == SAFE).Count();
            var prevRow = firstRow;

            for (int i = 1; i < totalRows; i++)
            {
                if (!rowMap.ContainsKey(prevRow))
                {
                    var newRow = new StringBuilder();
                    for (int j = 0; j < prevRow.Count(); j++)
                    {
                        var left = j == 0 ? SAFE : prevRow[j - 1];
                        var center = prevRow[j];
                        var right = j == prevRow.Count() - 1 ? SAFE : prevRow[j + 1];
                        newRow.Append(IsTrap($"{left}{center}{right}") ? TRAP : SAFE);
                    }
                    rowMap.Add(prevRow, newRow.ToString());
                }
                var currRow = rowMap[prevRow];
                safeTiles += currRow.Where(x => x == SAFE).Count();
                prevRow = currRow;
            }

            return safeTiles;
        }

        private static bool IsTrap(string v)
        {
            return (new bool[] { c1(v), c2(v), c3(v), c4(v) }.Count(x => x) == 1); 
        }
        private static bool c1(string v)
        {
            //Its left and center tiles are traps, but its right tile is not.
            return (v[0] == TRAP && v[1] == TRAP && v[2] == SAFE);
        }
        private static bool c2(string v)
        {
            //Its center and right tiles are traps, but its left tile is not.
            return (v[0] == SAFE && v[1] == TRAP && v[2] == TRAP);
        }
        private static bool c3(string v)
        {
            //Only its left tile is a trap.
            return (v[0] == TRAP && v[1] == SAFE && v[2] == SAFE);
        }
        private static bool c4(string v)
        {
            //Only its right tile is a trap.
            return (v[0] == SAFE && v[1] == SAFE && v[2] == TRAP);
        }






    }
}
