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
    public class Puzzle2016Day01Tests
    {
        [TestMethod()]
        public void ShortestDistanceOnGridTest1()
        {
            Assert.AreEqual(5, Day01.ShortestDistanceOnGrid("R2,L3"));
        }

        [TestMethod()]
        public void ShortestDistanceOnGridTest2()
        {
            Assert.AreEqual(2, Day01.ShortestDistanceOnGrid("R2,R2,R2"));
        }
        [TestMethod()]
        public void ShortestDistanceOnGridTest3()
        {
            Assert.AreEqual(12, Day01.ShortestDistanceOnGrid("R5,L5,R5,R3"));
        }
        [TestMethod()]
        public void ShortestDistanceOnGridTest4()
        {
                                                              
            Assert.AreEqual(146, Day01.ShortestDistanceOnGrid("R4,R4,L1,R3,L5,R2,R5,R1,L4,R3,L5,R2,L3,L4,L3,R1,R5,R1,L3,L1,R3,L1,R2,R2,L2,R5,L3,L4,R4,R4,R2,L4,L1,R5,L1,L4,R4,L1,R1,L2,R5,L2,L3,R2,R1,L194,R2,L4,R49,R1,R3,L5,L4,L1,R4,R2,R1,L5,R3,L5,L4,R4,R4,L2,L3,R78,L5,R4,R191,R4,R3,R1,L2,R1,R3,L1,R3,R4,R2,L2,R1,R4,L5,R2,L2,L4,L2,R1,R2,L3,R5,R2,L3,L3,R3,L1,L1,R5,L4,L4,L2,R5,R1,R4,L3,L5,L4,R5,L4,R5,R4,L3,L2,L5,R4,R3,L3,R1,L5,R5,R1,L3,R2,L5,R5,L3,R1,R4,L5,R4,R2,R3,L4,L5,R3,R4,L5,L5,R4,L4,L4,R1,R5,R3,L1,L4,L3,L4,R1,L5,L1,R2,R2,R4,R4,L5,R4,R1,L1,L1,L3,L5,L2,R4,L3,L5,L4,L1,R3"));
        }
        [TestMethod()]
        public void ShortestDistanceOnGridBetweenStartAndFirstDoublyVisitedLocationTest1()
        {
            Assert.AreEqual(4, Day01.ShortestDistanceOnGridBetweenStartAndFirstDoublyVisitedLocation("R8,R4,R4,R8"));
        }

        [TestMethod()]
        public void ShortestDistanceOnGridBetweenStartAndFirstDoublyVisitedLocationTest2()
        {

            Assert.AreEqual(131, Day01.ShortestDistanceOnGridBetweenStartAndFirstDoublyVisitedLocation("R4,R4,L1,R3,L5,R2,R5,R1,L4,R3,L5,R2,L3,L4,L3,R1,R5,R1,L3,L1,R3,L1,R2,R2,L2,R5,L3,L4,R4,R4,R2,L4,L1,R5,L1,L4,R4,L1,R1,L2,R5,L2,L3,R2,R1,L194,R2,L4,R49,R1,R3,L5,L4,L1,R4,R2,R1,L5,R3,L5,L4,R4,R4,L2,L3,R78,L5,R4,R191,R4,R3,R1,L2,R1,R3,L1,R3,R4,R2,L2,R1,R4,L5,R2,L2,L4,L2,R1,R2,L3,R5,R2,L3,L3,R3,L1,L1,R5,L4,L4,L2,R5,R1,R4,L3,L5,L4,R5,L4,R5,R4,L3,L2,L5,R4,R3,L3,R1,L5,R5,R1,L3,R2,L5,R5,L3,R1,R4,L5,R4,R2,R3,L4,L5,R3,R4,L5,L5,R4,L4,L4,R1,R5,R3,L1,L4,L3,L4,R1,L5,L1,R2,R2,R4,R4,L5,R4,R1,L1,L1,L3,L5,L2,R4,L3,L5,L4,L1,R3"));
        }
    }
}