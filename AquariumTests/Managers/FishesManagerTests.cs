using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aquarium.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aquarium.Models;

namespace Aquarium.Managers.Tests
{
    [TestClass()]
    public class FishesManagerTests
    {
        private FishesManager _manager = new FishesManager();
        [TestMethod()]
        public void GetByIdTest()
        {
            var actual = _manager.GetById(2).Name;
            var expected = "Digna";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            var actual = _manager.GetAll().Count;
            var expected = 4;

            Assert.AreEqual(expected, actual); 
        }
        [TestMethod()]
        public void AddTest()
        {
            var newFlower = _manager.GetById(3);
            _manager.Add(newFlower);
            var actual = _manager.GetById(5).Name;
            var expected = "Selchuk";

            Assert.AreEqual(actual, expected);

            var actual2 = _manager.GetAll().Count;
            var expected2 = 5;
            Assert.AreEqual(expected2, actual2);

            _manager.Delete(5);

        }

        [TestMethod()]
        public void DeleteTest()
        {
            var flower = _manager.GetById(1);
            _manager.Delete(1);
            var actual = _manager.GetAll().Count;
            var expected = 3;

            Assert.AreEqual(expected, actual);

            _manager.Add(flower);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Fish fish = new Fish() { Name = "Mariachi", Length = 100, Species = "Delspacito" };
            _manager.Update(2, fish);
            var actual = _manager.GetById(2).Name;
            var expected = "Mariachi";
            Assert.AreEqual(expected, actual);

        }
    }
}