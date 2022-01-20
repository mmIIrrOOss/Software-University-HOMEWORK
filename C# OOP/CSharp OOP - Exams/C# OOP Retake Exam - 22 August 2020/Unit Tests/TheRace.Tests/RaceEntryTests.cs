namespace TheRace.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;
    using System.Collections.Generic;

    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitDriver unitDriver;
        private Dictionary<string, UnitDriver> driver;

        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();
            this.unitDriver = new UnitDriver("Name", new UnitCar("Model", 100, 200));
            this.driver = new Dictionary<string, UnitDriver>();
        }

        [Test]
        public void Test_CtorWorkCorrect()
        {
            Assert.IsNotNull(raceEntry);
        }

        [Test]
        public void Test_WithCountShouldReturnCount()
        {

            //Arrange
            this.driver.Add("Name", unitDriver);
            var expCount = 1;

            //Act

            //Assert
            Assert.AreEqual(expCount, this.driver.Count);
        }

        [Test]
        public void Test_AddMethodShouldWithReturnIsNullResult()
        {

            //Arrange
            var expc = this.unitDriver = null;
            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(expc));
        }

        [Test]
        public void Test_AddMethodWithNameShouldWithReturnIsThrowsException()
        {

            //Arrange
            var unit = this.unitDriver;

            //Act
            this.raceEntry.AddDriver(unit);

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(unit));
        }

        [Test]
        public void Test_AddMethodWithNameShouldWithReturnCorrectResult()
        {

            //Arrange
            var unit = this.unitDriver;

            //Act
            string message = this.raceEntry.AddDriver(unit);

            //Assert
            Assert.AreEqual(message, $"Driver {unit.Name} added in race.");
        }

        [Test]
        public void Test_AddMethodWithNameShouldWithReturnCorrectItem()
        {

            //Arrange
            var unit = this.unitDriver;
            this.driver.Add(unit.Name, unit);

            //Act
            var actObject = this.driver.FirstOrDefault(x => x.Key == "Name");
            var actName = actObject.Key;
            var actObj = actObject.Value;
            //Assert
            Assert.AreEqual(unit.Name, actName);
            Assert.AreEqual(unit, actObject.Value);
        }

        [Test]
        public void TestCalculateAverageHorsePowerShouldWithThrowsException()
        {

            //Arrange
            this.driver.Add(unitDriver.Name, unitDriver);

            //Act


            //Assert
            Assert.Throws<InvalidOperationException>(
                () =>
               this.raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePower_ReturnsTheCorrectResult()
        {
            UnitDriver testDriverTwo = new UnitDriver("TestDriver2", new UnitCar("Model", 200, 50.0));
            raceEntry.AddDriver(unitDriver);
            raceEntry.AddDriver(testDriverTwo);

            double expectedAverage = (unitDriver.Car.HorsePower + testDriverTwo.Car.HorsePower) / 2;

            Assert.AreEqual(expectedAverage, raceEntry.CalculateAverageHorsePower());

        }
    }
}