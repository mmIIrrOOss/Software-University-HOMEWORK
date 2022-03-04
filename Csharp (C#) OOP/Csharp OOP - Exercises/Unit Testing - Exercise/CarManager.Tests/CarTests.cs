namespace Tests
{
    using NUnit.Framework;
    using System;

    //using CarManager;

    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfCostructorWorksCurrectly()
        {
            //Arrange
            string makeEx = "Audi";
            string modelEx = "RS8";
            double FuelConsumptionEx = 5.2;
            double FuelCapacityEx = 60;
            Car car = new Car(makeEx, modelEx, FuelConsumptionEx, FuelCapacityEx);

            //Act
            string makeAct = car.Make;
            string modelAct = car.Model;
            double FuelConsumptionAct = car.FuelConsumption;
            double FuelCapacityAct = car.FuelCapacity;

            //Assert
            Assert.AreEqual(makeEx, makeAct);
            Assert.AreEqual(modelEx, modelAct);
            Assert.AreEqual(FuelConsumptionEx, FuelConsumptionAct);
            Assert.AreEqual(FuelCapacityEx, FuelCapacityAct);
        }

        [TestCase(null)]
        [TestCase("")]
        public void TestWithLikeMakeIsNullOrEmptyThrows(string make)
        {

            //Arrange
            string model = "RS8";
            double fuelConsumption = 9;
            double fuelCapacity = 90;
            //Act

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        [TestCase(null)]
        [TestCase("")]
        public void TestWithModelIsNullOrEmptyThrows(string model)
        {

            //Arrange
            string make = "Audi";
            double fuelConsumption = 9;
            double fuelCapacity = 90;
            //Act

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void TestWithFuelConsumptionIsNegativeOrZeroThrows(double fuelConsumption)
        {

            //Arrange
            string make = "Audi";
            string model = "RS8";
            double fuelCapacity = 90;
            //Act

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void TestWithFuelCapacityIsNegativeOrZeroThrows(double fuelCapacity)
        {

            //Arrange
            string make = "Audi";
            string model = "RS8";
            double fuelConsumption = 9;
            //Act

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }


        [TestCase(0)]
        [TestCase(-1)]
        public void TestWithRefuelIsNegativeOrZeroThrows(double fuelToRefuel)
        {

            //Arrange
            string make = "Audi";
            string model = "RS8";
            double fuelConsumption = 9;
            double fuelCapacity = 90;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuelToRefuel);
            });
        }

        [Test]
        public void ShouldRefuelNormaly()
        {
            //Arrange
            string make = "Audi";
            string model = "RS8";
            double fuelConsumption = 9;
            double fuelCapacity = 90;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            
            //Act
            car.Refuel(10);
            double expectedFuelAmomunt = 10;
            double actualFuelAmmount = car.FuelAmount;

            //Assert
            Assert.AreEqual(expectedFuelAmomunt, actualFuelAmmount);
        }

        [Test]
        public void ShouldRefuelUnitTheTotalFuelCapacity()
        {
            //Arrange
            string make = "Audi";
            string model = "RS8";
            double fuelConsumption = 9;
            double fuelCapacity = 100;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            
            //Act
            car.Refuel(100);
            double expectedFuelAmomunt = 100;
            double actualFuelAmmount = car.FuelAmount;

            //Assert
            Assert.AreEqual(expectedFuelAmomunt, actualFuelAmmount);
        }

        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        public void ShouldRefuelShouldThrowArgumentExceptionWhenInputAmountIsBellowZero(
            double inputAmount)
        {
            //Arrange
            string make = "Audi";
            string model = "RS8";
            double fuelConsumption = 9;
            double fuelCapacity = 100;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            //Asseert
            Assert.Throws<ArgumentException>(
                () => car.Refuel(inputAmount));
        }

        [Test]
        public void IfShouldTestSuccessToRefulelAndGetFuelCapacity()
        {

            //Arrange
            string make = "Audi";
            string model = "RS8";
            double fuelConsumption = 9;
            double fuelCapacity = 90;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            double fuelToRefuel = 10;
            double fuelCapacityExpected = car.FuelCapacity;
            //Act
            car.Refuel(fuelToRefuel);
            double actualy = car.FuelCapacity;

            //Assert
            Assert.AreEqual(fuelCapacityExpected, actualy);
        }

        [Test]
        public void TestDriveMethodWithThrowsExceptionButWasGreedyDistance()
        {

            //Arrange
            string make = "Audi";
            string model = "RS8";
            double fuelConsumption = 9;
            double fuelCapacity = 90;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            //Act
            double distance = 1000;
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(distance);
            }
            );
        }
        [Test]
        public void TestDriveMethodWithThrowsExceptionButWasDistance()
        {

            //Arrange
            string make = "Audi";
            string model = "RS8";
            double fuelConsumption = 2;
            double fuelCapacity = 100;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            //Act
            double distance = 20;

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(distance);
            }
            );
        }

        [Test]
        public void TestDriveMethodWithThrowExceptionButWasGreedyDistance()
        {

            //Arrange
            string make = "Audi";
            string model = "RS8";
            double fuelConsumption = 2;
            double fuelCapacity = 100;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            //Act
            car.Refuel(20);
            car.Drive(20);
            double expectedFuelAmount = 19.6;
            double actualFuelAmount = car.FuelAmount;

            //Assert
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        [TestCase(null, "RS", 10, 20)]
        [TestCase("Audi", null, 10, 20)]
        [TestCase("Audi", "RS", 0, 20)]
        [TestCase("Audi", "RS", 10, -20)]
        [TestCase("Audi", "RS", 10, 0)]
        public void ValidateAllPropertiesShouldThrowArgumentExceptionForInvalidValues(
            string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert
                .Throws<ArgumentException>(()=> 
                           new Car(make,model,fuelConsumption,fuelCapacity));
        }
    }
}