using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.SleighPuzzles
{
    public static class Day09
    {
        public static string Decompress(string input)
        {
            var sb = new StringBuilder();
            var regex = new Regex(@"(\d*)x(\d*)\)");

            var split = input.Split(new char[] { '(' }, 2);
            string remainder = "";
            sb.Append(split[0]);
            while (split.Length > 1)
            {
                remainder = split[1];
                var match = regex.Match(remainder);
                var charCount = Convert.ToInt32(match.Groups[1].Value);
                var repeatCount = Convert.ToInt32(match.Groups[2].Value);
                var stringToRepeat = remainder.Substring(match.Length, charCount);
                var expandedSection = string.Concat(Enumerable.Repeat(stringToRepeat, repeatCount));
                sb.Append(expandedSection);
                //remove the expression from the string
                remainder = regex.Replace(remainder, "", 1);
                //remove the characters that were replaced
                remainder = remainder.Substring(charCount, remainder.Length - charCount);
                split = remainder.Split(new char[] { '(' }, 2);
                sb.Append(split[0]);
            }
            //sb.Append(remainder);
            return sb.ToString();
        }

        public static long GetDecompressedSize(string input)
        {
            long finalCount = 0;
            var regex = new Regex(@"(\d*)x(\d*)\)");
            var split = input.Split(new char[] { '(' }, 2);

            string remainder = "";
            finalCount = split[0].Length;

            while (split.Length > 1)
            {
                remainder = split[1];
                var match = regex.Match(remainder);
                var charCount = Convert.ToInt32(match.Groups[1].Value);
                var repeatCount = Convert.ToInt32(match.Groups[2].Value);
                var stringToRepeat = remainder.Substring(match.Length, charCount);
                finalCount += checked(repeatCount * GetDecompressedSize(stringToRepeat));

                //remove the expression from the string
                remainder = regex.Replace(remainder, "", 1);
                //remove the characters that were replaced
                remainder = remainder.Substring(charCount, remainder.Length - charCount);
                split = remainder.Split(new char[] { '(' }, 2);
                finalCount += split[0].Length;
            }

            return finalCount;
        }
    }
}
