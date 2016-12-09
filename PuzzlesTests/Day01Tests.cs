using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode.SnowPuzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.SnowPuzzles.Tests
{
    [TestClass()]
    public class Day01Tests
    {
        [TestMethod()]
        public void CountFloorsTest_0()
        {
            Assert.AreEqual(0, Day01.CountFloors("(())"));
            Assert.AreEqual(0, Day01.CountFloors("()()"));
        }

        [TestMethod()]
        public void CountFloorsTest_Negative3()
        {
            Assert.AreEqual(-3, Day01.CountFloors(")))"));
            Assert.AreEqual(-3, Day01.CountFloors(")())())"));
        }

        [TestMethod()]
        [DeploymentItem(@"Inputs\", "Inputs")]
        public void CountFloorsTest_Part1()
        {
            string testData = System.IO.File.ReadAllText(@"Inputs\day01.txt").Replace("\r", "");
            Assert.AreEqual(138, Day01.CountFloors(testData));
        }

        [TestMethod()]
        [DeploymentItem(@"Inputs\", "Inputs")]
        public void CountFloorsTest_Part2()
        {
            string testData = System.IO.File.ReadAllText(@"Inputs\day01.txt").Replace("\r", "");
            Assert.AreEqual(1771, Day01.FirstBasementCharIndex(testData));
        }
    }
}