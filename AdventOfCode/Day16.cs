using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Utils;

namespace AdventOfCode
{
    public static class Day16
    {
        public static List<bool> FindChecksum(List<bool> input, int diskSize)
        {
            var checksum = new List<bool>();
            var randomData = new List<bool>(input);

            while (randomData.Count < diskSize)
            {
                var newChunk = randomData.ReverseAndFlipBits();
                var newRandomData = new List<bool>();
                newRandomData.AddRange(randomData);
                newRandomData.Add(false);
                newRandomData.AddRange(newChunk);
                randomData = newRandomData;
            }
            var checksumData = randomData.Take(diskSize).ToList();
            do
            {
                checksum.Clear();
                for (int i = 0; i < checksumData.Count - 1; i += 2)
                {
                    checksum.Add(checksumData[i] == checksumData[i + 1]);
                }
                checksumData.Clear();
                checksumData.AddRange(checksum);

            } while (checksum.Count % 2 != 1);
            return checksum;
        }
    }
}
