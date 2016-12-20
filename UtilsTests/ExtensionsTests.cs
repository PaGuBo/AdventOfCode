using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace AdventOfCode.Utils.Tests
{
    [TestClass()]
    public class ExtensionsTests
    {
        [TestMethod()]
        public void ReverseAndFlipBitsTest_1()
        {
            var inputArray = new List<bool> { true, true, false};
            var expectedOutput = new List<bool> { true, false, false };
            var flippedAndReversedArray = inputArray.ReverseAndFlipBits();
            CollectionAssert.AreEqual(expectedOutput, flippedAndReversedArray);
        }

        [TestMethod()]
        public void ReverseAndFlipBitsTest_2()
        {
            var inputArray = new List<bool>{ true, true, true, true };
            var expectedOutput = new List<bool> { false, false, false, false };
            var flippedAndReversedArray = inputArray.ReverseAndFlipBits();
            CollectionAssert.AreEqual(expectedOutput, flippedAndReversedArray);
        }

        [TestMethod()]
        public void ReverseAndFlipBitsTest_3()
        {
            var inputArray =     new List<bool>{ true, false, true, true, false };
            var expectedOutput = new List<bool>{ true, false, false, true, false};
            var flippedAndReversedArray = inputArray.ReverseAndFlipBits();
            CollectionAssert.AreEqual(expectedOutput, flippedAndReversedArray);
        }
    }
}