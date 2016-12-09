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
    public class Day03Tests
    {
        [TestMethod()]
        public void VisitHousesTest_0()
        {
            Assert.AreEqual(2, Day03.CountVisitedHouses(">"));
            Assert.AreEqual(4, Day03.CountVisitedHouses("^>v<"));
            Assert.AreEqual(2, Day03.CountVisitedHouses("^v^v^v^v^v"));
        }

        [TestMethod()]
        [DeploymentItem(@"Inputs\", "Inputs")]
        public void VisitHousesTest_1()
        {
            string testData = System.IO.File.ReadAllText(@"Inputs\Day03.txt").Replace("\r", "");
            Assert.AreEqual(2081, Day03.CountVisitedHouses(testData));
        }

        [TestMethod()]
        public void VisitHousesWithRoboSantaTest_0()
        {
            Assert.AreEqual(3, Day03.CountVisitedHousesWithRobotSanta("^v"));
            Assert.AreEqual(3, Day03.CountVisitedHousesWithRobotSanta("^>v<"));
            Assert.AreEqual(11, Day03.CountVisitedHousesWithRobotSanta("^v^v^v^v^v"));
        }

        [TestMethod()]
        [DeploymentItem(@"Inputs\", "Inputs")]
        public void VisitHousesWithRoboSantaTest_1()
        {
            string testData = System.IO.File.ReadAllText(@"Inputs\Day03.txt").Replace("\r", "");
            Assert.AreEqual(2341, Day03.CountVisitedHousesWithRobotSanta(testData));
        }
    }
}