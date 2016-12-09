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
    public class Day09Tests
    {
        [TestMethod()]
        public void DecompressTest_1()
        {
            Assert.AreEqual("ADVENT", Day09.Decompress("ADVENT"));
        }

        [TestMethod()]
        public void DecompressTest_2()
        {
            Assert.AreEqual("ABBBBBC", Day09.Decompress("A(1x5)BC"));
        }

        [TestMethod()]
        public void DecompressTest_3()
        {
            Assert.AreEqual("(1x3)A", Day09.Decompress("(6x1)(1x3)A"));
        }

        [TestMethod()]
        public void DecompressTest_4()
        {
            Assert.AreEqual("X(3x3)ABC(3x3)ABCY", Day09.Decompress("X(8x2)(3x3)ABCY"));
        }

        [TestMethod()]
        [DeploymentItem(@"Inputs\", "Inputs")]
        public void DecompressTest_5()
        {
            string testData = System.IO.File.ReadAllText(@"Inputs\day09.txt").Replace("\r", "");
            var result = Day09.Decompress(testData);
            Assert.AreEqual(107035, result.Length);
        }

        [TestMethod()]
        public void GetDecompressedSizeTest()
        {
            Assert.AreEqual(241920, Day09.GetDecompressedSize("(27x12)(20x12)(13x14)(7x10)(1x12)A"));
        }

        [TestMethod()]
        public void GetDecompressedSizeTest_1()
        {
            Assert.AreEqual(125, Day09.GetDecompressedSize("(11x5)(6x5)(1x5)A"));
        }



        [TestMethod()]
        public void GetDecompressedSizeTest_3()
        {
            Assert.AreEqual(445, Day09.GetDecompressedSize("(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN"));
        }
        

        [TestMethod()]
        [DeploymentItem(@"Inputs\", "Inputs")]
        public void GetDecompressedSizeTest_2()
        {
            string testData = System.IO.File.ReadAllText(@"Inputs\day09.txt").Replace("\r", "");
            var result = Day09.GetDecompressedSize(testData);
            Assert.AreEqual(11451628995, result);
        }

    }
}