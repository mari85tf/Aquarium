using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aquarium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aquarium.Controllers;

namespace Aquarium.Models.Tests
{
    [TestClass()]
    public class FishTests
    {
        private Fish fish = new Fish() { Id=1, Length = 100, Name = "Maria", Species = "Carp" };
        private Fish nullNameFish = new Fish() { Length = 100, Name = null, Species = "Carp" };
        private Fish oneCharNameFish = new Fish() { Length = 100, Name = "M", Species = "Carp" };
        private Fish nullSpeciesFish = new Fish() { Length = 100, Name = "Maria", Species = null };
        private Fish oneCharSpeciesFish = new Fish() { Length = 100, Name = "Maria", Species = "C" };
        private Fish negLengthFish = new Fish() { Length = -100, Name = "Maria", Species = "Carp" };
        [TestMethod()]
        public void ValidateNameTest()
        {
            fish.ValidateName();

            Assert.ThrowsException<ArgumentNullException>(() => nullNameFish.ValidateName());
            Assert.ThrowsException<ArgumentException>(() => oneCharNameFish.ValidateName());
        }

        [TestMethod()]
        public void ValidateSpeciesTest()
        {
            fish.ValidateSpecies();

            Assert.ThrowsException<ArgumentNullException>(() => nullSpeciesFish.ValidateSpecies());
            Assert.ThrowsException<ArgumentException>(() => oneCharSpeciesFish.ValidateSpecies());
        }

        [TestMethod()]
        public void ValidateLengthTest()
        {
            fish.ValidateLength();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => negLengthFish.ValidateLength());
        }

        [TestMethod()]
        public void ValidateTest()
        {
            fish.Validate();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            string actual = fish.ToString();
            string expected = "Id: 1 Name: Maria Species: Carp Length: 100";

            Assert.AreEqual(expected, actual);
        }


    }
}