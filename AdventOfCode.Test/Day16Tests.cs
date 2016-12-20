using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using AdventOfCode.Utils;

namespace AdventOfCode.Tests
{
    [TestClass()]
    public class Day16Tests
    {
        [TestMethod()]
        public void FindChecksumTest_1()
        {
            var inputArray = "10000".Select(x => x == '1' ? true : false).ToList();
            var diskSize = 20;
            var computedOutput = Day16.FindChecksum(inputArray, diskSize);
            Assert.AreEqual("01100", computedOutput.ToBitString());
        }

        [TestMethod()]
        public void FindChecksumTest_2()
        {
            var inputArray = "01111010110010011".Select(x => x == '1' ? true : false).ToList();
            var diskSize = 272;
            var computedOutput = Day16.FindChecksum(inputArray, diskSize);
            Assert.AreEqual("00100111000101111", computedOutput.ToBitString());
        }

        [TestMethod()]
        public void FindChecksumTest_3()
        {
            var inputArray = "01111010110010011".Select(x => x == '1' ? true : false).ToList();
            var diskSize = 35651584;
            var computedOutput = Day16.FindChecksum(inputArray, diskSize);
            Assert.AreEqual("00100111000101111", computedOutput.ToBitString());
        }
    }
}