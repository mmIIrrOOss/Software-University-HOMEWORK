namespace Chainblock.Tests
{
    using NUnit.Framework;

    using Chainblock.Models;
    using Chainblock.Contracts;
    using Chainblock.ExceptionMessages;

    [TestFixture]
    public class TransactionTests
    {

        [Test]
        public void TestIfConstructorWorksCurrectly()
        {

            //Arrange
            int id = 1;
            TransactionStatus transactionStatus = TransactionStatus.Successfull;
            string from = "Pesho";
            string to = "Gosho";
            double amount = 15;

            ITransaction transaction = new Transaction(id,
                                       transactionStatus,from,to,amount);

            //Act


            //Assert
            Assert.AreEqual(id, transaction.Id);
            Assert.AreEqual(transactionStatus, transaction.Status);
            Assert.AreEqual(from,transaction.From);
            Assert.AreEqual(to, transaction.To);
            Assert.AreEqual(amount, transaction.Amount);

        }

        [TestCase(-10)]
        [TestCase(0)]
        public void TestWithLikeInvalidId(int id)
        {
            //Arrange
            
            TransactionStatus transactionStatus = TransactionStatus.Successfull;
            string from = "Pesho";
            string to = "Gosho";
            double amount = 15;

            //Assert
            Assert.That(() =>
            {
                ITransaction transaction = new Transaction(id,
                                           transactionStatus, from, to, amount);
            }, 
            Throws.ArgumentException
            .With.Message.
            EqualTo(ExceptionMessages.InvalidIdMessage));

        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void TestWithLikeInvalidSenderName(string from)
        {
            //Arrange
            int id = 1;
            TransactionStatus transactionStatus = TransactionStatus.Successfull;
            string to = "Gosho";
            double amount = 15;

            //Assert
            Assert.That(() =>
            {
                ITransaction transaction = new Transaction(id,
                                           transactionStatus, from, to, amount);
            },
            Throws.ArgumentException
            .With.Message.
            EqualTo(ExceptionMessages.InvalidSenderUsernameMessage));

        }
        
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void TestWithLikeInvalidRecieverrName(string to)
        {
            //Arrange
            int id = 1;
            TransactionStatus transactionStatus = TransactionStatus.Successfull;
            string from = "Pesho";
            double amount = 15;

            //Assert
            Assert.That(() =>
            {
                ITransaction transaction = new Transaction(id,
                                           transactionStatus, from, to, amount);
            },
            Throws.ArgumentException
            .With.Message.
            EqualTo(ExceptionMessages.InvalidReciverUsernameMessage));

        }

        [TestCase(-5.0)]
        [TestCase(-0.0000001)]
        [TestCase(0.0)]
        public void TestWithLikeInvalidAmount(double amount)
        {
            //Arrange
            int id = 1;
            TransactionStatus transactionStatus = TransactionStatus.Successfull;
            string from = "Pesho";
            string to = "Gosho";

            //Assert
            Assert.That(() =>
            {
                ITransaction transaction = new Transaction(id,
                                           transactionStatus, from, to, amount);
            },
            Throws.ArgumentException
            .With.Message.
            EqualTo(ExceptionMessages.InvalidTransactionAmauntMessage));

        }




        //Arrange


        //Act


        //Assert


    }
}
