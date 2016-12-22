using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.SleighPuzzles
{
    public static class Day22
    {
        public class Node
        {
            public Node(int x, int y, int size, int used, int avail, int percent)
            {
                X = x;
                Y = y;
                Size = size;
                Used = used;
                Avail = avail;
                Percent = percent;
            }

            public int X { get; set; }
            public int Y { get; set; }
            public int Size { get; set; }
            public int Used { get; set; }
            public int Avail { get; set; }
            public int Percent { get; set;  }
            public override string ToString()
            {
                return $"[({X,2},{Y,2} size-{Size,3} used-{Used,3} avail-{Avail,3} percent-{Percent,3})]";
            }
        }
        public static int CountViablePairs(List<string> input)
        {
            //greater than 892
            //1750 is wrong
            //1868 is wrong
            var pattern = new Regex(@"^\/dev\/grid\/node-x(?<xpos>\d*)-y(?<ypos>\d*)\s*(?<size>\d*)T\s*(?<used>\d*)T\s*(?<avail>\d*)T\s*(?<percent>\d*)%$");
            var nodes = new List<Node>();

            foreach(var line in input)
            {
                var m = pattern.Match(line).Groups;
                nodes.Add(new Node(
                    Convert.ToInt32(m["xpos"].Value),
                    Convert.ToInt32(m["ypos"].Value),
                    Convert.ToInt32(m["size"].Value),
                    Convert.ToInt32(m["used"].Value),
                    Convert.ToInt32(m["avail"].Value),
                    Convert.ToInt32(m["percent"].Value)));
            }
            int pairs = 0;

            nodes.ForEach(nodeA => nodes.ForEach(nodeB =>
            {
                if (nodeA != nodeB && nodeA.Used > 0 && nodeA.Used <= nodeB.Avail) pairs++;
            }));

            return pairs;
        }
    }
}
