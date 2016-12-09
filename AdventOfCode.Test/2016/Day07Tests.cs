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
    public class Day07Tests
    {
        [TestMethod()]
        [DeploymentItem(@"2016\Inputs\", "Inputs")]
        public void CountTlsSupportedTest1Part1()
        {
            string testData = System.IO.File.ReadAllText(@"Inputs\day07simple.txt").Replace("\r", "");
            Assert.AreEqual(2, Day07.CountTlsSupported(testData.Split('\n').ToList()));
        }
        [TestMethod()]
        [DeploymentItem(@"2016\Inputs\", "Inputs")]
        public void CountTlsSupportedTest2Part1()
        {
            string testData = System.IO.File.ReadAllText(@"Inputs\day07hard.txt").Replace("\r", "");
            Assert.AreEqual(105, Day07.CountTlsSupported(testData.Split('\n').ToList()));
        }

        [TestMethod()]
        [DeploymentItem(@"2016\Inputs\", "Inputs")]
        public void CountTlsSupportedTest1Part2()
        {
            string testData = System.IO.File.ReadAllText(@"Inputs\day07simpleSsl.txt").Replace("\r", "");
            Assert.AreEqual(3, Day07.CountSslSupported(testData.Split('\n').ToList()));
        }
        [TestMethod()]
        [DeploymentItem(@"2016\Inputs\", "Inputs")]
        public void CountTlsSupportedTest2Part2()
        {
            string testData = System.IO.File.ReadAllText(@"Inputs\day07hard.txt").Replace("\r", "");
            Assert.AreEqual(258, Day07.CountSslSupported(testData.Split('\n').ToList()));
        }

    }
}