using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzles.Tests
{
    [TestClass()]
    public class Day05Tests
    {
        [TestMethod()]
        [DeploymentItem(@"Inputs\", "Inputs")]
        public void CountNiceStringTest_0()
        {
            string testData = System.IO.File.ReadAllText(@"Inputs\naughtyNiceStringsSimple.txt").Replace("\r", "");
            Assert.AreEqual(2, Day05.CountNiceString(testData));
        }

        [TestMethod()]
        [DeploymentItem(@"Inputs\", "Inputs")]
        public void CountNiceStringTest_1()
        {
            string testData = System.IO.File.ReadAllText(@"Inputs\naughtyNiceStringsHard.txt").Replace("\r", "");
            Assert.AreEqual(255, Day05.CountNiceString(testData));
        }

        [TestMethod()]
        [DeploymentItem(@"Inputs\", "Inputs")]
        public void CountNiceStringPart2Test_0()
        {
            string testData = System.IO.File.ReadAllText(@"Inputs\naughtyNiceStringsSimple2.txt").Replace("\r", "");
            Assert.AreEqual(2, Day05.CountNiceStringsPart2(testData));
        }

        [TestMethod()]
        [DeploymentItem(@"Inputs\", "Inputs")]
        public void CountNiceStringPart2Test_1()
        {
            string testData = System.IO.File.ReadAllText(@"Inputs\naughtyNiceStringsHard.txt").Replace("\r", "");
            Assert.AreEqual(55, Day05.CountNiceStringsPart2(testData));
        }

    }
}