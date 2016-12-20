using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests
{
    [TestClass()]
    public class Day14Tests
    {
        [TestMethod()]
        public void FindIndexOfXKeyTest_1()
        {
            Assert.AreEqual(22728, Day14.FindIndexOfXKey(64, "abc"));
        }

        [TestMethod()]
        public void FindIndexOfXKeyTest_2()
        {
            Assert.AreEqual(23769, Day14.FindIndexOfXKey(64, "cuanljph"));
        }

        [TestMethod()]
        public void FindIndexOfXKeyTestWithStretchedHashes_1()
        {
            Assert.AreEqual(22551, Day14.FindIndexOfXKeyUsingStretchedHash(64, "abc"));
        }

        [TestMethod()]
        public void FindIndexOfXKeyTestWithStretchedHashes_2()
        {
            Assert.AreEqual(20606, Day14.FindIndexOfXKeyUsingStretchedHash(64, "cuanljph"));
        }
    }
}