namespace Presents.Tests
{
    using NUnit.Framework;
    using Presents;

    [TestFixture]
    public class PresentsTests
    {
        private Present present;

        [SetUp]
        public void Setup()
        {
            this.present = new Present("Name", 5.0);
        }

        [Test]
        public void TestIfWorkingCtorCorrect()
        {
            //Assert
            Assert.IsNotNull(this.present);
        }

        [Test]
        public void TestIfWorkingPropertyNameCorrect()
        {
            //Assert
            Assert.IsNotNull(this.present.Name);
            Assert.AreEqual("Name", this.present.Name);
        }

        [Test]
        public void TestIfWorkingPropertyMagicCorrect()
        {
            //Assert
            Assert.IsNotNull(this.present.Magic);
            Assert.AreEqual(5.0, this.present.Magic);
        }
    }
}
