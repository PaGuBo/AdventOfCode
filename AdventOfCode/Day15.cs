using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Disk
    {
        public int TotalPositions { get; private set; }
        public int CurrentPosition { get; set; }
        public Disk(int totalPositions, int currentPosition)
        {
            TotalPositions = totalPositions;
            CurrentPosition = currentPosition;
        }
    }
    public static class Day15
    {
        public static int Solve(List<Disk> disks)
        {
            bool pass = false;
            var t = 0;
            while (!pass)
            {
                pass = true;
                for (int diskIndex = 0; diskIndex < disks.Count; diskIndex++)
                {
                    if ((disks[diskIndex].CurrentPosition + t + diskIndex + 1)% (disks[diskIndex].TotalPositions) != 0)
                    {
                        pass = false;
                        break;
                    }
                }
                if (!pass) //can't think straight, hack to fix an off-by-one error
                {
                    t++;
                }
            }
            return t;
        }
    }
}
