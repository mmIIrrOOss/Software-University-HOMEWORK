namespace Robots.Tests
{
    using NUnit.Framework;

    using Robots;

    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;

        [SetUp]
        public void Setup()
        {
            this.robot = new Robot("Name", 100);
        }

        [Test]
        public void TestCtorRobotIfWorkingCorrect()
        {
            //Arrange
            var expName = "Name";
            var expMaxBattery = 100;
            var expBattery = 100;

            //Act

            //Assert
            Assert.IsNotNull(this.robot);
            Assert.AreEqual(expName, this.robot.Name);
            Assert.AreEqual(expMaxBattery, this.robot.MaximumBattery);
            Assert.AreEqual(expBattery, this.robot.Battery);

        }
    }
}
