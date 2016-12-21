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
    public class Day19Tests
    {
        [TestMethod()]
        public void SolveTestNext_1()
        {
            Assert.AreEqual(3, Day19.SolveStealFromNextElf(5));
        }

        [TestMethod()]
        public void SolveTestNext_2()
        {
            Assert.AreEqual(1816277, Day19.SolveStealFromNextElf(3005290));
        }

        [TestMethod()]
        public void SolveTestAcross_1()
        {
            Assert.AreEqual(2, Day19.SolveStealFromElfAcross_SLOW(5));
        }

        [TestMethod()]
        public void SolveTestAcross_2()
        {
            Assert.AreEqual(2, Day19.SolveStealFromElfAcross_SLOW(3005290));
        }

        [TestMethod()]
        public void SolveTestAcross_3()
        {
            Assert.AreEqual(2, Day19.SolveStealFromElfAcross_Attempt2(5));
        }

        [TestMethod()]
        public void SolveTestAcross_4()
        {
            Assert.AreEqual(1410967, Day19.SolveStealFromElfAcross_Attempt2(3005290));
        }
    }
}