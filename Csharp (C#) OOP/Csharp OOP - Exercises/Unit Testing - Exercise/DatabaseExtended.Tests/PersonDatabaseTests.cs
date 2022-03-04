namespace DatabaseExtended.Tests
{
    using NUnit.Framework;
    using DatabaseExtended;

    public class PersonDatabaseTests
    {
        private Person pesho;
        private Person goshó;


        [SetUp]
        public void Setup()
        {
            this.goshó = new Person(1111, "Gosho");
            this.pesho = new Person(5555, "Pesho");
        }

        //[Test]
        //public void TestWithConstructorWorkingIsCurrectly()
        //{
        //    //Arrange
        //    var extendedPerson = new Person[] { this.pesho, this.goshó };
        //    var dbexpected = new ExtendedDatabase(extendedPerson);
        //    //Act
        //    var actual = dbexpected.Fetch();
        //    //Assert
        //    Assert.That(actual, Is.EqualTo(extendedPerson));
        //}

        //[Test]
        //public void TestShouldWithAddOnValidPerson()
        //{
        //    //Arrange
        //    var persons = new Person[] { this.pesho, this.goshó };
        //    var db = new ExtendedDatabase(persons);
        //    var newPerson = new Person(2222, "Stamat");
        //    db.Add(newPerson);
        //    //Act
        //    var actual = db.Fetch();
        //    var expected = new Person[] { this.pesho, this.goshó, newPerson };

        //    //Assert
        //    Assert.That(actual, Is.EqualTo(expected));
        //}
        [Test]
        public void ConstructorShoudInitializeCollection()
        {
            var expected = new Person[] { pesho, goshó };

            var db = new Database(expected);

            var actual = db.Fetch();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void AddShouldAddValidPerson()
        {
            var persons = new Person[] { pesho, goshó };
            var db = new Database(persons);
            var newPerson = new Person(554466, "Stamat");
            db.Add(newPerson);

            var actual = db.Fetch();
            var expected = new Person[] { pesho, goshó, newPerson };

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestShouldWithAddUsernameThrowsInvalidOperationException()
        {
            //Arrange
            var persons = new Person[] { this.pesho, this.goshó };
            var db = new Database(persons);
            var newPerson = new Person(2222, "Gosho");
            //Act

            //Assert
            Assert.That(() => db.Add(newPerson),
                Throws.InvalidOperationException);
        }

        [Test]
        public void TestShouldWithAddSameThrowsInvalidOperationException()
        {
            //Arrange
            var persons = new Person[] { this.pesho, this.goshó };
            var db = new Database(persons);
            var newPerson = new Person(5555, "Stamat");
            //Act

            //Assert
            Assert.That(() => db.Add(newPerson),
                Throws.InvalidOperationException);
        }

        //[Test]
        //public void TestShouldWithRemove()
        //{
        //    //Arrange
        //    var persons = new Person[] { this.pesho, this.goshó };
        //    var db = new ExtendedDatabase(persons);
        //    db.Remove();

        //    //Act
        //    var actual = db.Fetch();
        //    var expected = new Person[] { pesho };
        //    //Assert
        //    Assert.That(actual, Is.EqualTo(expected));
        //}
        [Test]
        public void RemoveShouldRemove()
        {
            var persons = new Person[] { pesho, goshó };
            var db = new Database(persons);
            db.Remove();

            var actual = db.Fetch();
            var expected = new Person[] { pesho };

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void RemoveEmtyCollectionShouldThrow()
        {
            //Arrange
            var person = new Person[] { };
            var db = new Database(person);

            //Assert
            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUserNameExistingPersonShouldReturnPerson()
        {
            //Arrange
            var persons = new Person[] { this.pesho, this.goshó };
            var db = new Database(persons);

            //Act
            var expected = pesho;
            var actual = db.FindByUsername("Pesho");

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FindByUserNameExistingPersonShouldThrowsInvalidOperationException()
        {
            //Arrange
            var persons = new Person[] { this.pesho, this.goshó };
            var db = new Database(persons);

            //Act

            //Assert
            Assert.That(() => db.FindByUsername("Stamat"), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUserNameExistingPersonShouldThrowsArgumentNullException()
        {
            //Arrange
            var persons = new Person[] { this.pesho, this.goshó };
            var db = new Database(persons);

            //Act

            //Assert
            Assert.That(() => db.FindByUsername(null), Throws.ArgumentNullException);
        }

        [Test]
        public void FindByUserNameCaseSensetivethrows()
        {
            //Arrange
            var persons = new Person[] { this.pesho, this.goshó };
            var db = new Database(persons);

            //Act

            //Assert
            Assert.That(() => db.FindByUsername("GOSHO"), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByExistingPersonShouldReturnPerson()
        {
            //Arrange
            var persons = new Person[] { this.pesho, this.goshó };
            var db = new Database(persons);

            //Act
            var expected = pesho;
            var actual = db.FindById(5555);

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FindByNonExistingPersonShouldThrow()
        {
            //Arrange
            var persons = new Person[] { this.pesho, this.goshó };
            var db = new Database(persons);

            //Act

            //Assert
            Assert.That(() => db.FindById(558877), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByNonExistingPersonShouldNegativeArgumentThrow()
        {
            //Arrange
            var persons = new Person[] { this.pesho, this.goshó };
            var db = new Database(persons);

            //Act

            //Assert
            Assert.That(() => db.FindById(-5), Throws.Exception);
        }
    }
}
