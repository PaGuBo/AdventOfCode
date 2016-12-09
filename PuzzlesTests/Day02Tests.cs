using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.SnowPuzzles.Tests
{
    [TestClass()]
    public class Day02Tests
    {
        [TestMethod()]
        [DeploymentItem(@"Inputs\", "Inputs")]
        public void HowMuchWrappingPaperTest_1()
        {
            string testData = System.IO.File.ReadAllText(@"Inputs\Day02b.txt").Replace("\r", "");
            Assert.AreEqual(101, Day02.HowMuchWrappingPaper(testData));
        }

        [TestMethod()]
        [DeploymentItem(@"Inputs\", "Inputs")]
        public void HowMuchWrappingPaperTest_2()
        {
            string testData = System.IO.File.ReadAllText(@"Inputs\Day02a.txt").Replace("\r", "");
            Assert.AreEqual(1586300, Day02.HowMuchWrappingPaper(testData));
        }

        [TestMethod()]
        [DeploymentItem(@"Inputs\", "Inputs")]
        public void HowMuchRibbonTest_1()
        {
            string testData = System.IO.File.ReadAllText(@"Inputs\Day02a.txt").Replace("\r", "");
            Assert.AreEqual(3737498, Day02.HowMuchRibbon(testData));
        }
    }
}