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
    public class Day15Tests
    {
        [TestMethod()]
        public void SolveTest_1()
        {
            var disks = new List<Disk>
            {
                new Disk(5, 4),
                new Disk(2, 1)
            };

            Assert.AreEqual(5, Day15.Solve(disks));
        }

        [TestMethod()]
        public void SolveTest_2()
        {
            var disks = new List<Disk>
            {
                new Disk(7, 0),
                new Disk(13, 0),
                new Disk(3, 2),
                new Disk(5, 2),
                new Disk(17, 0),
                new Disk(19, 7),
            };

            Assert.AreEqual(121834, Day15.Solve(disks));
        }

        [TestMethod()]
        public void SolveTest_3()
        {
            var disks = new List<Disk>
            {
                new Disk(7, 0),
                new Disk(13, 0),
                new Disk(3, 2),
                new Disk(5, 2),
                new Disk(17, 0),
                new Disk(19, 7),
                new Disk(11, 0)
            };

            Assert.AreEqual(3208099, Day15.Solve(disks));
        }
    }



}