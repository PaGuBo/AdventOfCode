using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day20
    {
        public class Range
        {
            public long Min;
            public long Max;
            public Range(long min, long max)
            {
                Min = min;
                Max = max;
            }
        }
        public static long LowestAllowedIp(string[] ranges)
        {
            var cleanRanges = new List<Range>();
            foreach (var range in ranges)
            {
                var s = range.Split('-');
                var low = Convert.ToInt64(s[0]);
                var high = Convert.ToInt64(s[1]);
                var newRange = new Range(low, high);
                AddNewRangeToList(cleanRanges, newRange);
            }

            cleanRanges = cleanRanges.Distinct().OrderBy(x => x.Min).ToList();
            var firstRange = cleanRanges.First();

            return firstRange.Min > 0 ? 0 : firstRange.Max + 1;
        }

        public static long NumberOfAllowedIps(string[] ranges)
        {
            var cleanRanges = new List<Range>();
            foreach (var range in ranges)
            {
                var s = range.Split('-');
                var low = Convert.ToInt64(s[0]);
                var high = Convert.ToInt64(s[1]);
                var newRange = new Range(low, high);
                AddNewRangeToList(cleanRanges, newRange);
            }

            cleanRanges = cleanRanges.Distinct().OrderBy(x => x.Min).ToList();
            long allowedIpsCount = 0;
            if (cleanRanges[0].Min > 0)
            {
                allowedIpsCount += cleanRanges[0].Min - 1;
            }
            for (int i = 1; i < cleanRanges.Count(); i++)
            {
                allowedIpsCount += cleanRanges[i].Min - cleanRanges[i - 1].Max - 1;
            }
            allowedIpsCount += uint.MaxValue - cleanRanges[cleanRanges.Count() - 1].Max;
            return allowedIpsCount;
        }
        private static void AddNewRangeToList(List<Range> cleanRanges, Range newRange)
        {
            //check if the new range falls inside any existing ranges. The new range can be ignored in this case
            var rangesThatCoverTheNewRange = cleanRanges.Where(x => x.Min <= newRange.Min && x.Max >= newRange.Max);
            if (!rangesThatCoverTheNewRange.Any()) 
            {
                //check if any ranges fall totally inside new range. They can be removed
                var rangesInsideNewRange = cleanRanges.Where(x => x.Min >= newRange.Min && x.Max <= newRange.Max).ToList();
                //check if any ranges start inside the new range
                var rangesThatStartInsideNewRange = cleanRanges.Where(x => x.Min >= newRange.Min && x.Min <= newRange.Max + 1).ToList();
                //check if any ranges end inside the new range
                var rangesThatEndInsideNewRange = cleanRanges.Where(x => x.Max >= newRange.Min - 1 && x.Max <= newRange.Max).ToList();
                if (rangesInsideNewRange.Any())
                {
                    foreach (var r in rangesInsideNewRange)
                    {
                        cleanRanges.Remove(r);
                    }
                    cleanRanges.Add(newRange);
                }
                if (rangesThatStartInsideNewRange.Any())
                {
                    var newMax = rangesThatStartInsideNewRange.OrderByDescending(x => x.Max).First().Max;
                    foreach (var r in rangesThatStartInsideNewRange)
                    {
                        cleanRanges.Remove(r);
                    }
                    AddNewRangeToList(cleanRanges, new Range(newRange.Min, newMax));
                }
                if (rangesThatEndInsideNewRange.Any())
                {
                    var newMin = rangesThatEndInsideNewRange.OrderBy(x => x.Min).First().Min;
                    foreach (var r in rangesThatEndInsideNewRange)
                    {
                        cleanRanges.Remove(r);
                    }
                    AddNewRangeToList(cleanRanges, new Range(newMin, newRange.Max));
                }
                //if the range doesn't overlap anything, just add it
                if (!rangesInsideNewRange.Any() && !rangesThatStartInsideNewRange.Any() && !rangesThatEndInsideNewRange.Any())
                {
                    cleanRanges.Add(newRange);
                }
            }

        }
    }
}
