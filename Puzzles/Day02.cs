using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.SnowPuzzles
{
    public static class Day02
    {
        public static int HowMuchWrappingPaper(string input)
        {
            var area = 0;
            foreach(var box in input.Split('\n'))
            {
                var boxArray = box.Split('x')
                                  .Select(x => Convert.ToInt32(x))
                                  .OrderBy(x => x).ToList();
                var l = boxArray[0];
                var w = boxArray[1];
                var h = boxArray[2];

                area += 2 * l * w +
                        2 * w * h +
                        2 * h * l +
                        l * w;
            }
            return area;
        }

        public static int HowMuchRibbon(string input)
        {
            var ribonLength = 0;
            foreach (var box in input.Split('\n'))
            {
                var boxArray = box.Split('x')
                                  .Select(x => Convert.ToInt32(x))
                                  .OrderBy(x => x).ToList();
                var l = boxArray[0];
                var w = boxArray[1];
                var h = boxArray[2];

                ribonLength += l + l + w + w + (l * w * h);
            }
            return ribonLength;
        }
    }
}
