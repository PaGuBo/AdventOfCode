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
    public class Day18Tests
    {
        [TestMethod()]
        public void SafeTilesCountTest_1()
        {
            Assert.AreEqual(38, Day18.SafeTilesCount(".^^.^.^^^^", 10));
        }

        [TestMethod()]
        public void SafeTilesCountTest_2()
        {
            Assert.AreEqual(1987, Day18.SafeTilesCount(".^.^..^......^^^^^...^^^...^...^....^^.^...^.^^^^....^...^^.^^^...^^^^.^^.^.^^..^.^^^..^^^^^^.^^^..^", 40));
        }

        [TestMethod()]
        public void SafeTilesCountTest_3()
        {
            Assert.AreEqual(38, Day18.SafeTilesCount(".^.^..^......^^^^^...^^^...^...^....^^.^...^.^^^^....^...^^.^^^...^^^^.^^.^.^^..^.^^^..^^^^^^.^^^..^", 400000));
        }

    }
}