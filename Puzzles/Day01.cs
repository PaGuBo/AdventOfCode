using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.SnowPuzzles
{
    public static class Day01
    {
        public static int CountFloors(string input)
        {
            var foo = input.GroupBy(x => x).Select(g => new
            {
                Paren = g.Key,
                Count = g.Count()
            });
            var up = foo.FirstOrDefault(x => x.Paren == '(')?.Count;
            var down = foo.FirstOrDefault(x => x.Paren == ')')?.Count;
            return up.GetValueOrDefault() - down.GetValueOrDefault();
        }

        public static int FirstBasementCharIndex(string input)
        {
            int currentFloor = 0;
            int index = 0;
            while(currentFloor >=0)
            {
                if(input[index] == '(')
                {
                    currentFloor++;
                }
                else
                {
                    currentFloor--;
                }
                index++;
            }
            return index;
        }
    }
}
