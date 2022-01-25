namespace Robots.Tests
{

    using Robots;

    using System;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class RobotManagerTests
    {
        private RobotManager robotManager;
        private Robot robot;
        private List<Robot> robots;

        [SetUp]
        public void Setup()
        {
            this.robotManager = new RobotManager(5);
            this.robot = new Robot("Name", 100);
            this.robots = new List<Robot>();
        }

        [Test]
        public void TestConstructorIfWorkingCorrect()
        {
            //Arrange
            var expCapacity = 5;

            //Act

            //Assert
            Assert.IsNotNull(this.robotManager);
            Assert.AreEqual(expCapacity, this.robotManager.Capacity);

        }

        [Test]
        public void TestProperyCapacityShouldWithReturnThrowsExxcetpion()
        {

            //Arrange
            var expCpacity = -1;
            //Act

            //Assert
            Assert.Throws<ArgumentException>(()
                =>
            {
                new RobotManager(expCpacity);
            });

        }

        [Test]
        public void TestPropertyCountReturnCorrectResult()
        {

            //Arrange
            var expCount = 1;

            //Act
            this.robotManager.Add(this.robot);
            var actCount = this.robotManager.Count;
            //Assert
            Assert.AreEqual(expCount, actCount);

        }

        [Test]
        public void AddMehtodShouldReturnExistObjectWithThrowsException()
        {

            //Arrange

            //Act
            this.robotManager.Add(this.robot);

            //Assert
            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    this.robotManager.Add(this.robot);
                }
            );

        }

        [Test]
        public void AddMehtodShouldCountAndCapacityEqualttWithThrowsException()
        {

            //Arrange

            //Act
            this.robotManager.Add(this.robot);
            this.robotManager.Add(new Robot("Names", 96));
            this.robotManager.Add(new Robot("Namess", 97));
            this.robotManager.Add(new Robot("Namesss", 98));
            this.robotManager.Add(new Robot("Namessss", 99));

            //Assert
            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    this.robotManager.Add(new Robot("Namesssss", 100));
                }
            );

        }

        [Test]
        public void AddMehtodShouldtWithRetunCorrect()
        {

            //Arrange

            //Act

            //Assert
            Assert.DoesNotThrow(
                () =>
                {
                    this.robotManager.Add(this.robot);
                }
            );

        }

        [Test]
        public void RemoveMehtodShouldtWithThrowsException()
        {

            //Arrange

            //Act
            this.robotManager.Add(this.robot);

            //Assert
            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    this.robotManager.Remove("Az robotyt");
                }
            );

        }

        [Test]
        public void RemoveMehtodShouldtWithSuccessRemoved()
        {

            //Arrange

            //Act
            this.robotManager.Add(this.robot);

            //Assert
            Assert.DoesNotThrow(
                () =>
                {
                    this.robotManager.Remove("Name");
                }
            );

        }

        [Test]
        public void WorkMethodShouldWithThrowsExceptionForNullRobot()
        {
            //Arrange

            //Act
            this.robotManager.Add(this.robot);

            //Assert
            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    this.robotManager.Work("Az robotyt", "xvurli se ot prozoreca", 100);
                }
            );

        }

        [Test]
        public void WorkMethodShouldWithThrowsExceptionForSmallBatteryUse()
        {
            //Arrange

            //Act
            this.robotManager.Add(this.robot);

            //Assert
            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    this.robotManager.Work("Name", "xvurli se ot prozoreca", 101);
                }
            );

        }

        [Test]
        public void WorkMethodShouldWithSuccesWorkingOperation()
        {
            //Arrange

            //Act
            this.robotManager.Add(this.robot);

            //Assert
            Assert.DoesNotThrow(
                () =>
                {
                    this.robotManager.Work("Name", "xvurli se ot prozoreca", 99);
                }
            );

        }

        [Test]
        public void ChargeMethodForRobotShouldWithThrowsExceptionReturnRobotNull()
        {
            //Arrange

            //Act
            this.robotManager.Add(this.robot);

            //Assert
            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    this.robotManager.Charge("Az robotyt");
                }
            );
        }

        [Test]
        public void ChargeMethodForRobotShouldWithChargeSucces()
        {
            //Arrange

            //Act
            this.robotManager.Add(this.robot);

            //Assert
            Assert.DoesNotThrow(
                () =>
                {
                    this.robotManager.Charge("Name");
                }
            );
        }


    }
}
