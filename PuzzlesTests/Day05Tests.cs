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
        public void CountNiceStringTest()
        {
            string testData = System.IO.File.ReadAllText(@"Inputs\naughtyNiceStrings.txt").Replace("\r", "");
            Assert.AreEqual(2, Day05.CountNiceString(testData));
        }

    }
}