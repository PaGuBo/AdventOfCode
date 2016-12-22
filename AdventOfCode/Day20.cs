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
            public int Min;
            public int Max;
        }
        public static int LowestAllowedIp(string[] ranges)
        {
            int lowest = 0;
            var cleanRanges = new List<Range>();
            foreach (var range in ranges)
            {
                var s = range.Split('-');
                var low = Convert.ToInt32(range[0]);
                var high = Convert.ToInt32(range[1]);
                var newRange = new Range() { Min = low, Max = high };

                //check if any ranges fall totally inside new range. They can be removed
                var rangesInsideNewRange = cleanRanges.Where(x => x.Min >= low && x.Max <= high);
                if (rangesInsideNewRange.Count() > 0)
                {
                    foreach (var r in rangesInsideNewRange)
                    {
                        cleanRanges.Remove(r);
                    }
                    cleanRanges.Add(newRange);
                }
                ////check if the end of the range falls inside another range
                //var rangesContainingLow = cleanRanges.Where(x => x.Min < low && x.Max > low);
                //if (rangesContainingLow.Count() > 0)
                //{
                //    foreach (var r in rangesContainingLow)
                //    {
                //        cleanRanges.Remove(r);
                //        newRange.Max = r.Max;
                //        cleanRanges.Add(newRange);

                //    }
                //}
                //else
                //{
                    
                //}
            }
            return lowest;
        }
    }
}
