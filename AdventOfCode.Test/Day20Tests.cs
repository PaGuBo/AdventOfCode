using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode.SleighPuzzles.Tests
{
    [TestClass()]
    public class Day20Tests
    {
        [TestMethod()]
        [DeploymentItem(@"Inputs\", "Inputs")]
        public void LowestAllowedIpTest_2()
        {
            var testData = System.IO.File.ReadAllLines(@"Inputs\day20full.txt");
            Assert.AreEqual(17348574, Day20.LowestAllowedIp(testData));
        }


        [TestMethod()]
        [DeploymentItem(@"Inputs\", "Inputs")]
        public void NumberOfAllowedIps_2()
        {
            var testData = System.IO.File.ReadAllLines(@"Inputs\day20full.txt");
            Assert.AreEqual(104, Day20.NumberOfAllowedIps(testData));
        }
    }
}