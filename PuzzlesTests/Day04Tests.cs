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
    public class Day04Tests
    {
        [TestMethod()]
        public void MineAdventCoinTest()
        {
            Assert.AreEqual(609043, Day04.MineAdventCoin("abcdef", 5));
            Assert.AreEqual(1048970, Day04.MineAdventCoin("pqrstuv", 5));
        }

        [TestMethod()]
        public void MineAdventCoinTest_1()
        {
            Assert.AreEqual(117946, Day04.MineAdventCoin("ckczppom", 5));
        }

        [TestMethod()]
        public void MineAdventCoinTest_2()
        {
            Assert.AreEqual(3938038, Day04.MineAdventCoin("ckczppom", 6));
        }
    }
}