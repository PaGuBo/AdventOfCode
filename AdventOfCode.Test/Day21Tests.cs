using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode.SleighPuzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.SleighPuzzles.Tests
{
    [TestClass()]
    public class Day21Tests
    {
        [TestMethod()]
        [DeploymentItem(@"Inputs\", "Inputs")]
        public void ScramblePasswordTest_0()
        {
            var input = System.IO.File.ReadLines(@"Inputs\day21a.txt").ToList();
            Assert.AreEqual("decab", Day21.ScramblePassword("abcde", input));
        }

        [TestMethod()]
        [DeploymentItem(@"Inputs\", "Inputs")]
        public void ScramblePasswordTest_b()
        {
            var input = System.IO.File.ReadLines(@"Inputs\day21b.txt").ToList();
            Assert.AreEqual("bdfhgeca", Day21.ScramblePassword("abcdefgh", input));
        }

        [TestMethod()]
        [DeploymentItem(@"Inputs\", "Inputs")]
        public void UnscramblePasswordTest_a()
        {
            var input = System.IO.File.ReadLines(@"Inputs\day21b.txt").ToList();
            Assert.AreEqual("gdfcabeh", Day21.Unscramble("fbgdceah", input));
        }
    }
}