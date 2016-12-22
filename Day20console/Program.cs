using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day20console
{
    class Program
    {
        static void Main(string[] args)
        {
            var randomData = new List<string>();
            var rand = new Random();
            var maxVal = 10000;
            for (int i = 0; i < 10; i++)
            {
                var low = rand.Next(maxVal);
                var high = rand.Next(low + 1, maxVal);
                randomData.Add($"{low}-{high}");
            }

            var x = Day20.LowestAllowedIp(randomData.ToArray());
            Console.ReadLine();
        }
    }
}
