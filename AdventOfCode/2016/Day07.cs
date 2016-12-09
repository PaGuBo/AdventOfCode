using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day07
    {
        public static int CountTlsSupported(List<string> input)
        {
            var retVal = 0;
            foreach(var ip in input)
            {
                var patternInsideBrackets = @"\[([a-z]*)\]";
                var patternOutsideBrackets = @"(^[a-z]*)\[|\]([a-z]*$)|\]([a-z]*)\[";

                Console.WriteLine(ip);

                var insideValues = new List<string>();
                var outsideValues = new List<string>();
                var insideMatches = Regex.Matches(ip, patternInsideBrackets);

                for (int i = 0; i < insideMatches.Count; i++)
                {
                    insideValues.Add(insideMatches[i].Value.Replace("[", "").Replace("]", ""));
                }

                var outsideMatches = Regex.Matches(ip, patternOutsideBrackets);
                
                for (int i = 0; i < outsideMatches.Count; i++)
                {
                    outsideValues.Add(outsideMatches[i].Value.Replace("[", "").Replace("]", ""));
                }

                Console.WriteLine("   Inside brackets");
                foreach (var insideValue in insideValues)
                {
                    Console.WriteLine("      " + insideValue);
                }

                Console.WriteLine("   Outside brackets");
                foreach (var outsideValue in outsideValues)
                {
                    Console.WriteLine("      " + outsideValue);
                }

                if(!insideValues.Any(x => IsAbba(x)) &&
                    outsideValues.Any(x => IsAbba(x)))
                {
                    retVal++;
                }

                Console.Write("\n");

            }
            return retVal;
        }


        public static int CountSslSupported(List<string> input)
        {
            var retVal = 0;
            foreach (var ip in input)
            {
                var patternInsideBrackets = @"\[([a-z]*)\]";
                var patternOutsideBrackets = @"(^[a-z]*)\[|\]([a-z]*$)|\]([a-z]*)\[";

                Console.WriteLine(ip);

                var insideValues = new List<string>();
                var outsideValues = new List<string>();
                var insideMatches = Regex.Matches(ip, patternInsideBrackets);

                for (int i = 0; i < insideMatches.Count; i++)
                {
                    insideValues.Add(insideMatches[i].Value.Replace("[", "").Replace("]", ""));
                }

                var outsideMatches = Regex.Matches(ip, patternOutsideBrackets);

                for (int i = 0; i < outsideMatches.Count; i++)
                {
                    outsideValues.Add(outsideMatches[i].Value.Replace("[", "").Replace("]", ""));
                }

                Console.WriteLine("   Inside brackets");
                foreach (var insideValue in insideValues)
                {
                    Console.WriteLine("      " + insideValue);
                }

                Console.WriteLine("   Outside brackets");
                foreach (var outsideValue in outsideValues)
                {
                    Console.WriteLine("      " + outsideValue);
                }


                var foo = new StringBuilder();
                var found = false;
                foreach (var outsideValue in outsideValues)
                {
                    for(int i = 0; i < outsideValue.Length - 2; i++)
                    {
                        if ((outsideValue[i] == outsideValue[i + 2]) &&
                            (outsideValue[i] != outsideValue[i + 1]))
                        {
                            foo.Clear();
                            foo.Append(outsideValue[i + 1]);
                            foo.Append(outsideValue[i]);
                            foo.Append(outsideValue[i + 1]);
                            if (insideValues.Any(x => x.Contains(foo.ToString())))
                            {
                                retVal++;
                                found = true;
                                break;
                            }
                        }
                    }
                    if (found)
                    {
                        break;
                    }
                }

                Console.Write("\n");

            }
            return retVal;
        }

        private static bool IsAbba(string brakets)
        {
            var isAbba = false;
            for(int i = 0; i < brakets.Length - 3; i++)
            {
                if(brakets[i]   == brakets[i + 3] &&
                   brakets[i+1] == brakets[i + 2] &&
                   brakets[i]   != brakets[i + 1])
                {
                    isAbba = true;
                    break;
                }
            }
            return isAbba;
        }
    }
}
