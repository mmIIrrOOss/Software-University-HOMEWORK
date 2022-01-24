namespace Presents.Tests
{
    using Presents;

    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class BagTests
    {
        private Bag bag;
        private Present present;
        private List<Present> presents;

        [SetUp]
        public void Setup()
        {
            this.bag = new Bag();
            this.present = new Present("Name", 5.0);
            this.presents = new List<Present>();
        }

        [Test]
        public void TestIfWorkCorrectCtor()
        {
            //Assert
            Assert.IsNotNull(this.bag);
        }

        [Test]
        public void CreateMethodShouldThrowExceptionReturnNullPresent()
        {
            //Arrange
            var present = this.present = null;

            //Assert
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    this.bag.Create(present);
                }
                );
        }

        [Test]
        public void CreateMethodShouldThrowExceptionReturnExistPresent()
        {
            //Arrange
            var present = this.present;
            this.bag.Create(present);

            //Assert
            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    this.bag.Create(present);
                }
                );
        }

        [Test]
        public void CreateMethodShouldReturnPresent()
        {
            //Arrange
            var present = this.present;
            this.bag.Create(present);

            //Assert
            Assert.AreEqual(this.present, this.bag.GetPresent("Name"));
        }

        [Test]
        public void CreateMethodShouldReturnPresentMessage()
        {
            //Arrange
            var present = this.present;
            var expMessage = $"Successfully added present {present.Name}.";
            //Act
            string actMessage = this.bag.Create(present);

            //Assert
            Assert.AreEqual(expMessage,actMessage);
        }

        [Test]
        public void RemoveMethodShouldReturnBoolResult()
        {
            //Arrange
            this.bag.Create(this.present);
            var expTrue = this.bag.Remove(this.present);
            var expFalse = this.bag.Remove(new Present("Present",5.0));

            //Assert
            Assert.IsTrue(expTrue);
            Assert.IsFalse(expFalse);
            CollectionAssert.IsEmpty(this.presents);
        }

        [Test]
        public void GetPresentWithLeastMagic()
        {
            //Arrange
            this.bag.Create(this.present);
            var actPesentLeastMagic = this.bag.GetPresentWithLeastMagic();

            //Assert
            Assert.AreEqual(this.present.Magic,actPesentLeastMagic.Magic);
        }

        [Test]
        public void GetPresent()
        {
            //Arrange
            this.bag.Create(this.present);

            //Assert
            Assert.AreEqual(this.present,this.bag.GetPresent("Name"));
        }

        [Test]
        public void GetPresentsAsReadonlyCollectionMethod()
        {
            //Assert
            CollectionAssert.AreEqual(this.presents.AsReadOnly(), this.bag.GetPresents());
        }
    }
}
