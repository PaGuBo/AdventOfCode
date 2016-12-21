using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day19
    {
        public class Elf
        {
            public int ElfId;
            public int GiftCount;
            public Elf NextElf;
            public Elf PrevElf;
            public Elf(int elfId, int giftCount, Elf nextElf = null, Elf prevElf = null)
            {
                ElfId = elfId;
                GiftCount = giftCount;
                NextElf = nextElf;
                PrevElf = prevElf;
            }
        }
        public static int SolveStealFromNextElf(int numberOfElves)
        {
            var q = new Queue<Elf>();
            for (int i = 1; i <= numberOfElves; i++)
            {
                q.Enqueue(new Elf(i, 1));
            }
            while (q.Count() > 1)
            {
                var thiefElf = q.Dequeue();

                if (q.Count > 0)
                {
                    var victumElf = q.Dequeue();
                    thiefElf.GiftCount += victumElf.GiftCount;
                }
                q.Enqueue(thiefElf);
            }
            return q.Dequeue().ElfId;
        }

        public static int SolveStealFromElfAcross_SLOW(int numberOfElves)
        {
            var elves = new List<Elf>();

            for (int i = 1; i <= numberOfElves; i++)
            {
                elves.Add(new Elf(i, 1));
            }

            while (elves.Count() > 1)
            {
                var oldThiefElf = elves[0];
                var newThiefElf = new Elf(oldThiefElf.ElfId, oldThiefElf.GiftCount);

                if (elves.Count > 1)
                {
                    var victumElf = elves[elves.Count / 2];
                    elves.Remove(victumElf);
                    newThiefElf.GiftCount += victumElf.GiftCount;
                }
                elves.Remove(oldThiefElf);
                elves.Add(newThiefElf);
            }
            return elves[0].ElfId;
        }
        public static int SolveStealFromElfAcross_Attempt2(int numberOfElves)
        {
            var rootElf = new Elf(1, 1);
            var prevElf = rootElf;
            Elf victumElf = new Elf(0, 0);
            for (int i = 2; i <= numberOfElves; i++)
            {
                prevElf.NextElf = new Elf(i, 1);
                prevElf.NextElf.PrevElf = prevElf;
                if (i == (numberOfElves / 2) + 1)
                {
                    victumElf = prevElf.NextElf;
                }
                prevElf = prevElf.NextElf;
            }
            prevElf.NextElf = rootElf;
            rootElf.PrevElf = prevElf;

            var thiefElf = rootElf;
            var count = numberOfElves;
            while (thiefElf.NextElf != thiefElf)
            {
                thiefElf.GiftCount += victumElf.GiftCount;

                victumElf.PrevElf.NextElf = victumElf.NextElf;
                victumElf.NextElf.PrevElf = victumElf.PrevElf;

                victumElf = count % 2 == 1 ? victumElf.NextElf.NextElf : victumElf.NextElf;


                count--;

                thiefElf = thiefElf.NextElf;
                var t = thiefElf;
            }

            return thiefElf.ElfId;
        }
    }
}
