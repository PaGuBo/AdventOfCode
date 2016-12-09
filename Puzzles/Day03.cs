using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode.SnowPuzzles
{
    public static class Day03
    {
        private static Dictionary<Point, int> VisitedHouses = new Dictionary<Point, int>();

        private static void VisitAllTheHouses(string input)
        {

            var currPos = new Point(0, 0);
            if (VisitedHouses.ContainsKey(currPos))
            {
                VisitedHouses[currPos]++;
            }
            else
            {
                VisitedHouses[currPos] = 1;
            }

            foreach (var direction in input)
            {
                switch (direction)
                {
                    case '^':
                        currPos.Y++;
                        break;
                    case '>':
                        currPos.X++;
                        break;
                    case 'v':
                        currPos.Y--;
                        break;
                    case '<':
                        currPos.X--;
                        break;
                }
                if (VisitedHouses.ContainsKey(currPos))
                {
                    VisitedHouses[currPos]++;
                }
                else
                {
                    VisitedHouses[currPos] = 1;
                }
            }
        }
        public static int CountVisitedHouses(string input)
        {
            VisitedHouses.Clear();
            return VisitedHouses.Count();
        }

        public static int CountVisitedHousesWithRobotSanta(string input)
        {
            VisitedHouses.Clear();
            var santasInput = new string(input.Where((c, i) => i % 2 == 0).ToArray());
            var roboSantasInput = new string(input.Where((c, i) => i % 2 != 0).ToArray());
            VisitAllTheHouses(santasInput);
            VisitAllTheHouses(roboSantasInput);
            return VisitedHouses.Count;
        }
    }
}
