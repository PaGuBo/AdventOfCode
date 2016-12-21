using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace AdventOfCode.Tests
{
    [TestClass()]
    public class Day17Tests
    {
        [TestMethod()]
        public void SolveTest_0()
        {
            Assert.AreEqual("No path exists", Day17.GetShortestPath("hijkl", new Point(0, 0), new Point(3, 3)));
        }
        
        [TestMethod()]
        public void SolveTest_1()
        {
            Assert.AreEqual("DDRRRD", Day17.GetShortestPath("ihgpwlah", new Point(0, 0), new Point(3, 3)));
        }

        [TestMethod()]
        public void SolveTest_2()
        {
            Assert.AreEqual("DDUDRLRRUDRD", Day17.GetShortestPath("kglvqrro", new Point(0, 0), new Point(3, 3)));
        }

        [TestMethod()]
        public void SolveTest_3()
        {
            Assert.AreEqual("DRURDRUDDLLDLUURRDULRLDUUDDDRR", Day17.GetShortestPath("ulqzkmiv", new Point(0, 0), new Point(3, 3)));
        }

        [TestMethod()]
        public void SolveTest_4()
        {
            Assert.AreEqual("DRRDRLDURD", Day17.GetShortestPath("pvhmgsws", new Point(0, 0), new Point(3, 3)));
        }

        [TestMethod()]
        public void LongestPathTest_1()
        {
            Assert.AreEqual(370, Day17.GetLongestPathLength("ihgpwlah", new Point(0, 0), new Point(3, 3)));
        }

        [TestMethod()]
        public void LongestPathTest_2()
        {
            Assert.AreEqual(492, Day17.GetLongestPathLength("kglvqrro", new Point(0, 0), new Point(3, 3)));
        }

        [TestMethod()]
        public void LongestPathTest_3()
        {
            Assert.AreEqual(830, Day17.GetLongestPathLength("ulqzkmiv", new Point(0, 0), new Point(3, 3)));
        }

        [TestMethod()]
        public void LongestPathTest_4()
        {
            Assert.AreEqual(830, Day17.GetLongestPathLength("pvhmgsws", new Point(0, 0), new Point(3, 3)));
        }
    }
}