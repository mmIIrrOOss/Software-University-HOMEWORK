namespace INStock.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ProductStockTests
    {
        private const string ProductLabel = "Test";
        private const string AnotherProductLabel = "Another Test";
        private Product product;
        private Product anotherProduct;
        private ProductStock productStock;

        [SetUp]
        public void SetUpProduct()
        {
            this.productStock = new ProductStock();
            this.product = new Product(ProductLabel, 10, 1);
            this.anotherProduct = new Product(AnotherProductLabel, 20, 5);
        }

        public void AddProductShouldSaveTheProduct()
        {
            //Act
            this.productStock.Add(this.product);

            //Assert
            var productInStock = productStock.FindByLabel(ProductLabel);
            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(ProductLabel));
            Assert.That(productInStock.Price, Is.EqualTo(10));
            Assert.That(productInStock.Quantity, Is.EqualTo(1));
        }

        [Test]
        public void AddProductShouldThrowExceptionDublicateLabel()
        {
            //Arrange & Act
            Assert.That(() =>
            {
                this.productStock.Add(this.product);
                this.productStock.Add(this.product);
            },
           //Assert
           Throws
                .Exception.InstanceOf<ArgumentException>()
                .With.Message
                .EqualTo($"A product with {ProductLabel} label arllready exists."));
        }

        [Test]
        public void AddingTwoProductsShouldSaveThem()
        {

            //Act
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            //Assert
            var firstProductInStock = productStock.FindByLabel(ProductLabel);

            var secondProductInStock = productStock.FindByLabel(AnotherProductLabel);

            Assert.That(firstProductInStock, Is.Not.Null);
            Assert.That(firstProductInStock.Label, Is.EqualTo(ProductLabel));
            Assert.That(firstProductInStock.Price, Is.EqualTo(10));
            Assert.That(firstProductInStock.Quantity, Is.EqualTo(1));


            Assert.That(secondProductInStock, Is.Not.Null);
            Assert.That(secondProductInStock.Label, Is.EqualTo(AnotherProductLabel));
            Assert.That(secondProductInStock.Price, Is.EqualTo(20));
            Assert.That(secondProductInStock.Quantity, Is.EqualTo(5));
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenProductIsNull()
        {
            Assert.Throws<ArgumentNullException>(
                //Arrange
                () => this.productStock.Remove(null),
               "Product cannot be null.");
        }

        [Test]
        public void RemoveShouldReturnTrueWhenProductIsRemoved()
        {
            //Arrange
            this.AddMultipleProductsToProductStock();
            var productToRemove = this.productStock.Find(3);

            //Act
            var result = this.productStock.Remove(productToRemove);

            //Asser
            Assert.That(result, Is.True);
            Assert.That(this.productStock.Count, Is.EqualTo(4));
            Assert.That(this.productStock[3].Label, Is.EqualTo("5"));
        }

        [Test]
        public void RemoveShouldReturnFalseWhenProductIsNotFound()
        {
            //Arrange
            this.AddMultipleProductsToProductStock();
            var productNotInStock = new Product(ProductLabel, 10, 20);

            //Act
            var result = this.productStock.Remove(productNotInStock);

            //Asser
            Assert.That(result, Is.False);
            Assert.That(this.productStock.Count, Is.EqualTo(5));
        }

        [Test]
        public void ContainsShouldReturnTrueWhenProductExists()
        {
            //Arrange
            this.productStock.Add(this.product);

            //Act
            var result = this.productStock.Contains(this.product);

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void ContainsShouldReturnFalseWhenProductDoesExist()
        {
            //Act
            var result = this.productStock.Contains(this.product);

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void ContainsShouldThrowExceptionWhenProductIsNull()
        {

            Assert.Throws<ArgumentNullException>(() =>
            this.productStock.Contains(null), "Product cannot be null.");
        }

        [Test]
        public void CountShouldReturnCorrectProductCount()
        {

            //Arrange
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);


            //Act
            var result = this.productStock.Count;

            //Assert
        }

        [Test]
        public void FindShouldReturnCorrectProductByIndex()
        {
            //Arrange
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            //Act
            var productInStock = this.productStock.Find(1);

            //Assert

            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(AnotherProductLabel));
            Assert.That(productInStock.Price, Is.EqualTo(20));
            Assert.That(productInStock.Quantity, Is.EqualTo(5));
        }

        [Test]
        public void FindShouldThrowExceptionWhenIndexOfRange()
        {
            //Arrange
            this.productStock.Add(this.product);

            //Act
            Assert.That(() =>
            {
                this.productStock.Find(1);
            },
           //Assert
           Throws
                .Exception.InstanceOf<IndexOutOfRangeException>()
                .With.Message
                .EqualTo($"Product index does not exists."));
        }

        [Test]
        public void FindShouldThrowExceptionIsIndexBellowZero()
        {
            //Arrange
            this.productStock.Add(this.product);

            // Act
            Assert.That(() =>
            {
                this.productStock.Find(-1);
            },
           //Assert
           Throws
                .Exception.InstanceOf<IndexOutOfRangeException>()
                .With.Message
                .EqualTo($"Product index does not exists."));
        }

        [Test]
        public void FindByLabelShouldThrowExceptionWhenLabelIsNull()
        {
            Assert.Throws<ArgumentNullException>(
                //Arrange
                () => this.productStock.FindByLabel(null),  "Product label cannot be null.");
        }

        [Test]
        public void ContainsShouldThrowExceptionWhenLabelIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            this.productStock.FindByLabel(null), "Product label cannot be null.");

            // //Arrange & Act
            // Assert.That(() =>
            // {
            //     this.productStock.FindByLabel(null);
            // },
            ////Assert
            //Throws
            //     .Exception.InstanceOf<ArgumentNullException>()
            //     .With.Message
            //     .EqualTo($"Product label cannot be null."));
        }

        [Test]
        public void ContainsShouldThrowExceptionWhenLabelIsDoesNotExists()
        {
            const string InvalidLabel = "Test";


            Assert.Throws<ArgumentException>(() =>
            this.productStock.FindByLabel(InvalidLabel), $"Product with {InvalidLabel} label could not be found.");
            // //Arrange & Act
            // Assert.That(() =>
            // {
            //     this.productStock.FindByLabel(InvalidLabel);
            // },
            ////Assert
            //Throws
            //     .Exception.InstanceOf<ArgumentNullException>()
            //     .With.Message
            //     .EqualTo($"Product with {InvalidLabel} label could not be found."));
        }

        [Test]
        public void FindByLabelShouldReturnCorrectProduct()
        {
            //Arrange
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            //Act
            var productInStock = this.productStock.FindByLabel(ProductLabel);

            //Assert
            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(ProductLabel));
            Assert.That(productInStock.Price, Is.EqualTo(10));
            Assert.That(productInStock.Quantity, Is.EqualTo(1));
        }

        [Test]
        public void FindByLabelShouldThrowExceptionWhenLabelDoesNotExists()
        {
            //Arrange
            string invalidLabel = "Invalid Label.";

            //Assert
            Assert.That(() =>
            this.productStock.FindByLabel(invalidLabel),
            Throws.Exception.With.Message
            .EqualTo($"Product with {invalidLabel} label could not be found."));

        }

        [Test]
        public void FindAllInPriceRangeShouldReturnEmptyCollectionWhenProblemsMatch()
        {

            //Arrange
            this.AddMultipleProductsToProductStock();

            //Act
            var result = this.productStock.FindAllInRange(30, 50);

            //Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void FindAllPriceRangeShouldReturnCorrectCollectionWithCorrectOrder()
        {
            //Arrange
            this.AddMultipleProductsToProductStock();

            //Act
            var result = this.productStock.FindAllInRange(4, 21).ToList();

            //Assert
            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(result[0].Price, Is.EqualTo(20));
            Assert.That(result[1].Price, Is.EqualTo(10));
            Assert.That(result[2].Price, Is.EqualTo(5));
        }

        [Test]
        public void FindAllByPriceShouldReturnEmptyCollectionWhenNoProductMatch()
        {

            //Arrange
            this.AddMultipleProductsToProductStock();

            //Act
            var result = this.productStock.FindAllByPrice(30);

            //Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void FindAllByPriceShouldReturnCorrectCollection()
        {

            //Arrange
            this.AddMultipleProductsToProductStock();

            //Act
            var result = this.productStock.FindAllByPrice(400).ToList();

            //Assert
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Label, Is.EqualTo("4"));
            Assert.That(result[1].Label, Is.EqualTo("5"));
        }

        [Test]
        public void FindMostExpensiveProductsShouldThrowExceptionWhenProductStockIsEmpty()
        {
            //Arrange & Act
            Assert.That(() =>
            {
                this.productStock.FindMostExpensiveProduct();
            },
             //Assert
             Throws
                  .Exception.InstanceOf<InvalidOperationException>()
                  .With.Message
                  .EqualTo($"Product stock is empty."));

        }

        [Test]
        public void FindMostExpensiveProductsShouldReturnCorrectProduct()
        {

            //Arrange
            this.AddMultipleProductsToProductStock();

            //Act
            var productStock = this.productStock.FindMostExpensiveProduct();

            //Assert

            Assert.That(productStock, Is.Not.Null);
            Assert.That(productStock.Label, Is.EqualTo("4"));
            Assert.That(productStock.Price, Is.EqualTo(400));
            Assert.That(productStock.Quantity, Is.EqualTo(4));
        }

        [Test]
        public void FindByAllQuantityShouldShouldBeReturnEmptyCollectionWhenNoProductMatch()
        {

            //Arrange
            this.AddMultipleProductsToProductStock();

            //Act
            var result = this.productStock.FindAllByQuantity(6);

            //Assert
            Assert.That(result, Is.Empty);
        }


        [Test]
        public void FindByAllQuantityShouldShouldBeReturnCorrectCollection()
        {
            //Arrange
            this.AddMultipleProductsToProductStock();

            //Act
            var result = this.productStock.FindAllByQuantity(5).ToList();

            //Assert
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Label, Is.EqualTo("5"));
        }


        [Test]
        public void GetEnumeratorShouldReturnCorrectInsertionOrder()
        {

            //Arrange
            this.AddMultipleProductsToProductStock();
            var result = (this.productStock//Act
                           ).ToList();

            //Assert
            Assert.That(result[0].Label, Is.EqualTo("1"));
            Assert.That(result[1].Label, Is.EqualTo("2"));
            Assert.That(result[2].Label, Is.EqualTo("3"));
            Assert.That(result[3].Label, Is.EqualTo("4"));
            Assert.That(result[4].Label, Is.EqualTo("5"));
        }


        [Test]
        public void GetIndexShouldReturnCorrectProductByIndex()
        {

            //Arrange
            this.productStock.Add(this.product);
            this.productStock.Add(this.anotherProduct);

            //Act
            var productInStock = this.productStock[1];

            //Assert
            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(AnotherProductLabel));
            Assert.That(productInStock.Price, Is.EqualTo(20));
            Assert.That(productInStock.Quantity, Is.EqualTo(5));
        }

        [Test]
        public void GetIndexShouldThrowExceptionWhenIndexIsOutOfRange()
        {

            //Arrange
            this.productStock.Add(this.product);

            Assert.That(
                //Act
                () => this.productStock[1],
                Throws.Exception.InstanceOf<IndexOutOfRangeException>()
                .With.Message.EqualTo("Product index does not exists."));
        }

        [Test]
        public void GetIndexShouldThrowExceptionWhenIndexIsBellowZero()
        {

            //Arrange
            this.productStock.Add(this.product);

            Assert.That(
                //Act
                () => this.productStock[-1],
                Throws.Exception.InstanceOf<IndexOutOfRangeException>()
                .With.Message.EqualTo("Product index does not exists."));
        }

        [Test]
        public void SetIndexShouldChangeProduct()
        {
            const string productLabel = "Yet Another Test";

            //Arrange
            this.AddMultipleProductsToProductStock();

            //Act
            this.productStock[3] = new Product(productLabel, 50, 3);

            //Assert
            var productInStock = this.productStock.Find(3);

            Assert.That(productInStock, Is.Not.Null);
            Assert.That(productInStock.Label, Is.EqualTo(productLabel));
            Assert.That(productInStock.Price, Is.EqualTo(50));
            Assert.That(productInStock.Quantity, Is.EqualTo(3));
        }


        [Test]
        public void SetIndexShouldThrowExceptionWhenIndexIsBellowZero()
        {

            //Arrange
            this.productStock.Add(this.product);

            Assert.That(
                //Act
                () => this.productStock[-1] = new Product(ProductLabel, 10, 10),
                Throws.Exception.InstanceOf<IndexOutOfRangeException>()
                .With.Message.EqualTo($"Product index does not exists."));
        }

        [Test]
        public void SetIndexShouldThrowExceptionWhenIndexOutOfRange()
        {

            //Arrange
            this.productStock.Add(this.product);

            Assert.That(
                //Act
                () => this.productStock[1] = new Product(ProductLabel, 10, 10),
                Throws.Exception.InstanceOf<IndexOutOfRangeException>()
                .With.Message.EqualTo($"Product index does not exists."));
        }

        //Arrange


        //Act


        //Assert

        private void AddMultipleProductsToProductStock()
        {
            this.productStock.Add(new Product("1", 10, 1));
            this.productStock.Add(new Product("2", 5, 2));
            this.productStock.Add(new Product("3", 20, 3));
            this.productStock.Add(new Product("4", 400, 4));
            this.productStock.Add(new Product("5", 400, 5));
        }

    }
}

