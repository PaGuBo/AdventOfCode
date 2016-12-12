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
                if (str.Where(c => vowels.Contains(c)).Count() >= 3 &&
                    str.Substring(0, str.Length - 1).Where((c, i) => str[i] == str[i + 1]).Count() > 0 &&
                    !forbidden.Any(x => str.Contains(x)))
                {
                    niceStrings++;
                }
            }
            return niceStrings;
        }

        public static int CountNiceStringsPart2(string input)
        {
            int niceStrings = 0;
            var strings = input.Split('\n');
            foreach (var str in strings)
            {
                if (PartTwoRuleOne(str) && PartTwoRuleTwo(str))
                {
                    niceStrings++;
                }
            }
            return niceStrings;
        }

        private static bool PartTwoRuleTwo(string str)
        {

            Console.WriteLine(str);
            for (int i = 0; i < str.Length - 3; i++)
            {
                var pair = str.Substring(i, 2);
                var right = i < str.Length - 2 ? str.Substring(i + 2) : null;
                //Console.WriteLine($"   [{pair}] [{right}]");
                if (right.Contains(pair))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool PartTwoRuleOne(string str)
        {
            return str.Substring(0, str.Length - 2).Where((c, i) => str[i] == str[i + 2]).Count() > 0;
        }
    }
}
