using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11.Tests
{
    [TestClass()] 
    public class BuildingTests
    {
        [TestMethod()]
        public void IsValidTest_1()
        {

            List<List<string>> map = new List<List<string>>{ new List<string> { "thul-gen", "thul-chp", "plut-gen", "stro-gen"},
                                                             new List<string> { "plut-chp", "stro-chp"},
                                                             new List<string> { "prom-gen", "prom-chp", "ruth-gen", "ruth-chp"},
                                                             new List<string> (){ } };

            Building building = new Building(map, 0);
            Assert.IsTrue(building.IsValid());
        }
        [TestMethod()]
        public void IsValidTest_2()
        {
            List<List<string>> map = new List<List<string>>{ new List<string> { "thul-gen", "thul-chp", "plut-gen", "stro-gen"},
                                                             new List<string> { "plut-chp", "stro-chp"},
                                                             new List<string> { "prom-chp", "ruth-gen", "ruth-chp"},
                                                             new List<string> { "prom-gen" } };

            Building building = new Building(map, 0);
            Assert.IsFalse(building.IsValid());
        }

        [TestMethod()]
        public void IsValidTest_3()
        {
            List<List<string>> map = new List<List<string>>{ new List<string> { "thul-gen", "thul-chp", "plut-gen"},
                                                             new List<string> { "plut-chp", "stro-chp", "stro-gen"},
                                                             new List<string> { "prom-gen", "prom-chp", "ruth-gen", "ruth-chp"},
                                                             new List<string> (){ } };

            Building building = new Building(map, 0);
            Assert.IsFalse(building.IsValid());
        }

        [TestMethod()]
        public void IsValidTest_4()
        {
            List<List<string>> map = new List<List<string>>{ new List<string> { "plut-gen", "stro-gen"},
                                                             new List<string> { "plut-chp", "stro-chp"},
                                                             new List<string> { "ruth-gen", "ruth-chp"},
                                                             new List<string> { "prom-gen", "prom-chp", "thul-gen", "thul-chp" } };

            Building building = new Building(map, 0);
            Assert.IsTrue(building.IsValid());
        }

        [TestMethod()]
        public void StateTest_1()
        {
            List<List<string>> map = new List<List<string>>{ new List<string> { "plut-gen", "stro-gen"},
                                                             new List<string> { "plut-chp", "stro-chp"},
                                                             new List<string> { "ruth-gen", "ruth-chp"},
                                                             new List<string> { "prom-gen", "prom-chp", "thul-gen", "thul-chp" } };

            Building building = new Building(map, 0);
            Assert.AreEqual("FLOOR 0: plut-gen stro-gen FLOOR 1: plut-chp stro-chp FLOOR 2: ruth-chp ruth-gen FLOOR 3: prom-chp prom-gen thul-chp thul-gen", building.State);
        }

        [TestMethod()]
        public void StateTest_2()
        {
            List<List<string>> map = new List<List<string>>{ new List<string> { "stro-gen", "plut-gen"},
                                                             new List<string> { "stro-chp", "plut-chp" },
                                                             new List<string> { "ruth-gen", "ruth-chp"},
                                                             new List<string> { "thul-gen", "prom-gen", "prom-chp", "thul-chp" } };

            Building building = new Building(map, 0);
            Assert.AreEqual("FLOOR 0: plut-gen stro-gen FLOOR 1: plut-chp stro-chp FLOOR 2: ruth-chp ruth-gen FLOOR 3: prom-chp prom-gen thul-chp thul-gen", building.State);
        }

    }
}