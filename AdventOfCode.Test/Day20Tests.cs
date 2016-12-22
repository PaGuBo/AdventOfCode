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
        [DeploymentItem(@"2016\Inputs\", "Inputs")]
        public void LowestAllowedIpTest()
        {
            var testData = System.IO.File.ReadAllLines(@"Inputs\Day20simple.txt");
            
            Assert.AreEqual(3, Day20.LowestAllowedIp(testData));
        }
    }
}