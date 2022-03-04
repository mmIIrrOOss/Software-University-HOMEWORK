namespace Aquariums.Tests
{
    using Aquariums;


    using System;
    using System.Linq;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class AquariumsTests
    {
        private Aquarium aquarium;
        private Fish fish;

        [SetUp]
        public void Setup()
        {
            this.aquarium = new Aquarium("Name", 9);
            this.fish = new Fish("Nemo");
        }

        [Test]
        public void TestIfWorkingCtorCorrect()
        {

            //Assert
            Assert.IsNotNull(this.aquarium);
        }

        [Test]
        public void TestIfWorkingPropertyNameCorrect()
        {

            //Assert
            Assert.AreEqual("Name", this.aquarium.Name);
        }

        [TestCase("")]
        [TestCase(null)]
        public void TestIfWorkingPropertyNameShouldWithReturnThrowsException(string name)
        {
            //Assert
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    this.aquarium = new Aquarium(name, 9);
                });
        }

        [Test]
        public void TestIfWorkingProperttCapacityShouldReturnCorrect()
        {
            //Assert
            Assert.AreEqual(9, this.aquarium.Capacity);
        }

        [Test]
        public void TestIfWorkingProperttyCpacityShouldWithThrowsExceptionNullCapacity()
        {
            //Assert
            Assert.Throws<ArgumentException>(
                () =>
                {
                    this.aquarium = new Aquarium("Name", -1);
                });
        }

        [Test]
        public void TestIfWorkingProperttCountCorrect()
        {
            //Arrange
            var list = new List<Fish>();
            list.Add(this.fish);
            var expCount = 1;

            //Act
            this.aquarium.Add(this.fish);

            //Assert
            Assert.AreEqual(expCount, this.aquarium.Count);
        }

        [Test]
        public void TestIfWorkingPropertyCapacityCorrect()
        {
            //Arrange

            Assert.IsNotNull(this.aquarium.Capacity);
        }

        [Test]
        public void AddMehtodTestShouldThrowsExceptionWithReturnNullFish()
        {
            //Arrange
            var aquarium = new Aquarium("Name",2);
            aquarium.Add(this.fish);
            aquarium.Add(this.fish);

            //Assert
            Assert.Throws<InvalidOperationException>(
                ()=>
                {
                    aquarium.Add(this.fish);
                });
        }

        [Test]
        public void RemoveMehtodTestShouldWithRemoveSuccessOperation()
        {
            //Arrange
            this.aquarium.Add(this.fish);

            //Assert
            Assert.DoesNotThrow(() => this.aquarium.RemoveFish("Nemo"));

        }

        [Test]
        public void SellFishMethodWorkCorrectly()
        {
            //Arrange
            this.aquarium.Add(this.fish);
            this.fish.Available = false;
            //Assert
            Assert.AreEqual(this.fish,this.aquarium.SellFish("Nemo"));

        }

        [Test]
        public void SellFishMethodShouldWithThrowsExceptionForReturnNullFish()
        {
            //Arrange

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.aquarium.SellFish("None");
            });

        }

        public void ReportMethod()
        {
            //Arrange
            var list = new List<Fish>();
            list.Add(this.fish);
            list.Add(new Fish("Moly"));

            string fishNames = string.Join(", ", list.Select(f => f.Name));
            string expReport = $"Fish available at Name: {fishNames}";

            //Act
            this.aquarium.Add(this.fish);
            this.aquarium.Add(new Fish("Moly"));
            string actReport =  this.aquarium.Report();

            //Assert
            Assert.AreEqual(expReport, actReport);


        }

    }
}
