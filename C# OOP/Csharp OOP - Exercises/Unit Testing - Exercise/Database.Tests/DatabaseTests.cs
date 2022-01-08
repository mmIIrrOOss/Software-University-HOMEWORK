namespace Tests
{
    using System;

    using NUnit.Framework;

    public class DatabaseTests
    {
        private Database database;
        private readonly int[] initialData = new int[] { 1, 2, 3 };

        [SetUp]
        public void Setup()
        {
            database = new Database(initialData);
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { })]
        public void TestIfConstrutorWorksCurrectly(int[] data)
        {
            //Arrange
            //int[] data = new int[] { 1, 2, 3 };
            this.database = new Database(data);

            //Act
            int expectedCount = data.Length;
            int actualCount = this.database.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]
        public void ConstructorShouldThrowExceptionWithBiggerColection()
        {
            //Arrange
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database = new Database(data);
            });
        }

        [Test]
        public void AddShouldIncreaseCountWhenAddedSuccesfully()
        {
            //Arrange
            int expecteCount = 3;
            int actualCount = this.database.Count;

            //Act
            this.database.Add(3);

            //Assert
            Assert.AreEqual(expecteCount, actualCount);
        }

        [Test]
        public void AddShouldThrowsExceptionWhenDatabaseFull()
        {
            //Arrange
            for (int i = 4; i <= 16; i++)
            {
                this.database.Add(i);
            }

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Add(17));
        }

        [Test]
        public void RemoveShouldDecreaseCountSuccesfully()
        {
            //Arrange
            int expecteCount = 3;
            int actualCount = this.database.Count;

            //Act
            this.database.Remove();

            //Assert
            Assert.AreEqual(expecteCount, actualCount);
        }

        [Test]
        public void RemoveShouldThrowsExcetpionWhenDatabaseEmpty()
        {
            //Act
            this.database.Remove();
            this.database.Remove();
            this.database.Remove();

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
                { 
                    this.database.Remove();
                }
               );
        }

        [TestCase(new int[] { 1,2,3})]
        [TestCase(new int[] { })]
        [TestCase(new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16 })]
        public void FetchShouldReturnCopyOfData(int[] expectedData)
        {
            //Arrange
            this.database = new Database(expectedData);

            //Act
            int[] arrayActual = this.database.Fetch();

            //Assert
            CollectionAssert.AreEqual(expectedData, arrayActual);
        }

    }
}