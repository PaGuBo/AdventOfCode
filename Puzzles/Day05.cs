using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzles
{
    public static class Day05
    {
        public static int CountNiceString(string input)
        {
            int niceStrings = 0;
            var strings = input.Split('\n');
            var vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };
            var forbidden = new List<string> { "ab", "cd", "pq", "xy" };
            foreach(var str in strings)
            {
                if (str.Where(c => vowels.Contains(c)).Distinct().Count() >= 3 &&
                    str.Substring(0, str.Length - 1).Where((c, i) => str[i] == str[i + 1]).Count() > 0 &&
                    !str.Any(
                    )
                {
                    
                }
            }
            return niceStrings;
        }
    }
}
