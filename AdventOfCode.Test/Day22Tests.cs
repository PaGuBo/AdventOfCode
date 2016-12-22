using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode.SleighPuzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.SleighPuzzles.Tests
{
    [TestClass()]
    public class Day22Tests
    {
        [TestMethod()]
        [DeploymentItem(@"Inputs\", "Inputs")]
        public void CountViablePairsTest()
        {
            var input = System.IO.File.ReadLines(@"Inputs\day22.txt").ToList();
            Assert.AreEqual(934, Day22.CountViablePairs(input.ToList()));
        }
    }
}