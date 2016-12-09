using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.SleighPuzzles
{
    public static class Day06
    {
        public static string DecodeCorruptedMessagePart1(List<string> input)
        {
            var output = new StringBuilder();
            var sb = new StringBuilder();
            for (int col = 0; col < input[0].Length; col++)
            {
                sb.Clear();
                for (int row = 0; row < input.Count; row++)
                {
                    sb.Append(input[row][col]);
                }
                var letter = sb.ToString().GroupBy(l => l)
                                          .Select(group => new
                                          {
                                             Letter = group.Key,
                                             Count = group.Count()
                                          }).OrderByDescending(x => x.Count)
                                            .ThenBy(x => x.Letter).First().Letter;
                output.Append(letter);

            }
            return output.ToString();
        }

        public static string DecodeCorruptedMessagePart2(List<string> input)
        {
            var output = new StringBuilder();
            var sb = new StringBuilder();
            for (int col = 0; col < input[0].Length; col++)
            {
                sb.Clear();
                for (int row = 0; row < input.Count; row++)
                {
                    sb.Append(input[row][col]);
                }
                var letter = sb.ToString().GroupBy(l => l)
                                          .Select(group => new
                                          {
                                              Letter = group.Key,
                                              Count = group.Count()
                                          }).OrderBy(x => x.Count)
                                            .ThenBy(x => x.Letter).First().Letter;
                output.Append(letter);

            }
            return output.ToString();
        }
    }
}
