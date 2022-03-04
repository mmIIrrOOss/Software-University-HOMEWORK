namespace INStock.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ProductTests
    {
        //Arrange

        //Act

        //Assert

        [Test]
        public void QuantittyCannotBeLessThanZero()
        {

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {

                //Arrange & Act
                var product = new Product("Test", 10, -1);
            }, "Quantity cannot be less than zero.");
        }

        [Test]
        public void LabelCannotBeNull()
        {

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {

                //Arrange & Act
                var product = new Product(null, 10, 5);
            }, "Label cannot be null or empty.");
        }

        [Test]
        public void LabelCannotBeEmpty()
        {

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {

                //Arrange & Act
                var product = new Product(string.Empty, 10, 5);
            }, "Label cannot be null or empty.");

        }
        [Test]
        public void PriceCannotBeLessThanZero()
        {

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {

                //Arrange & Act
                var product = new Product("Test", -10, 5);
            }, "Price cannot be less than zero.");
        }

        [Test]
        public void QuantityCannotBeLessThanZero()
        {

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {

                //Arrange & Act
                var product = new Product("Test", 10, -10);
            }, "Quantity cannot be less than zero.");
        }

        [Test]
        public void ProductShouldBeComparedByPriceWhenOrderIsCorrect()
        {
            //Arrange
            var firstProduct = new Product("Test 1", 30.5m, 3);
            var secondProduct = new Product("Test 1", 30.5m, 3);

            //Act
            var corectOrderResult = secondProduct.CompareTo(firstProduct);

            //Assert
            Assert.That(corectOrderResult == 0, Is.True);

        }

        

        [Test]
        public void ProductShouldBeComparedByPriceWhenOrderIsEqual()
        {
            //Arrange
            var firstProduct = new Product("Test 1", 30.5m, 3);
            var secondProduct = new Product("Test 2", 30.5m, 3);

            //Act
            var inCorectOrderResult = firstProduct.CompareTo(secondProduct);

            //Assert
            Assert.That(inCorectOrderResult == 0, Is.True);

        }
    }
}