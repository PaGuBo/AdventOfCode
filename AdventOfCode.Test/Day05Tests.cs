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
    public class Puzzle2016Day05Tests
    {
        [TestMethod()]
        public void GetDoorPasswordPart1Test1()
        {
            Assert.AreEqual("18f47a30", Day05.GetDoorPasswordPart1("abc"));
        }

        [TestMethod()]
        public void GetDoorPasswordPart1Test2()
        {
            Assert.AreEqual("801b56a7", Day05.GetDoorPasswordPart1("abbhdwsy"));
        }

        [TestMethod()]
        public void GetDoorPasswordPart2Test1()
        {
            Assert.AreEqual("05ace8e3", Day05.GetDoorPasswordPart2("abc"));
        }

        [TestMethod()]
        public void GetDoorPasswordPart2Test2()
        {
            Assert.AreEqual("424a0197", Day05.GetDoorPasswordPart2("abbhdwsy"));
        }
    }
}