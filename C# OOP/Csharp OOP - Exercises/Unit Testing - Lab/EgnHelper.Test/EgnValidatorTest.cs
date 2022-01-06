namespace EgnHelper.Test
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class EgnValidatorTest
    {
        [SetUp]
        public void BeforeExecution()
        {
            Console.WriteLine("Before");
        }

        [TearDown]
        public void AfterExecution()
        {
            Console.WriteLine("After");
        }

        [TestCase("7523169263")]
        [TestCase("6101057509")]
        [TestCase("7552010005")]
        public void IsVlidateMthodShouldReturnTrueForValidEgn(string egn)
        {
            //Arrange
            var validate = new EgnValidator();

            //Act
            var result = validate.IsValid(egn);

            //Assert
            Assert.AreEqual(true, result);
            Assert.That(result, Is.EqualTo(true));
        }

        [TestCase("1111111111", "Only ones")]
        [TestCase("0000000000", "Invalid day of month")]
        [TestCase("7523169269", "Invalid check sum")]
        [TestCase("7523169264", "Invalid check sum")]
        [TestCase("7502300005", "Invalid check sum")]
        public void IsVlidateMthod_ShouldReturnFalseForInvalidEgn(string egn, string message)
        {
            //Arrange
            var validate = new EgnValidator();

            //Act
            var result = validate.IsValid(egn);

            //Assert
            Assert.IsFalse(result,message);
        }

        [Test]
        public void IsVlidateMthod_ShouldReturnTrueForValidEgnFor19thCentury()
        {
            //Arrange
            var validate = new EgnValidator();

            //Act
            var result = validate.IsValid("7523169263");

            //Assert
            Assert.AreEqual(true, result);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void IsVlidateMthod_ShouldReturnTrueForValidEgnFor20thCentury()
        {
            //Arrange
            var validate = new EgnValidator();

            //Act
            var result = validate.IsValid("6101057509");

            //Assert
            Assert.AreEqual(true, result);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void IsVlidateMthod_ShouldReturnTrueForValidEgnFor21thCentury()
        {
            //Arrange
            var validate = new EgnValidator();

            //Act
            var result = validate.IsValid("7552010005");

            //Assert
            Assert.AreEqual(true, result);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void IsVlidateMthod_ShouldThrowAnExceptionWhenTheGivenArgumentIsNull()
        {
            //Arrange
            var validate = new EgnValidator();
            //Assert
            Assert.Throws<ArgumentNullException>(() => validate.IsValid(null));
        }
    }
}