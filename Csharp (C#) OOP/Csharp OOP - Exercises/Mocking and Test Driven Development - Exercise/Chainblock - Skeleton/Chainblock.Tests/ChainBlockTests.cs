namespace Chainblock.Tests
{
    using NUnit.Framework;

    using Chainblock.Core;
    using Contracts;
    using Models;
    using ExceptionMessages;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ChainBlockTests
    {
        private IChainblock chainBlock;
        private ITransaction transaction;
        [SetUp]
        public void Initialize()
        {
            this.chainBlock = new ChainBlock();
            this.transaction = new Transaction(
                1, TransactionStatus.Unauthorized, "Pesho", "Gosho", 10);
        }

        [Test]
        public void TestIfConstructorWorksCurrectly()
        {

            //Arrange
            int expectedInitialCount = 0;
            IChainblock chainblock = new ChainBlock();

            //Assert
            Assert.AreEqual(expectedInitialCount, chainblock.Count);
        }

        [Test]
        public void AddShouldIncreaseCountWhenSucces()
        {
            //Arrange
            int expectedCount = 1;
            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull
                , "Pesho", "Gosho", 10);

            //Act
            this.chainBlock.Add(transaction);

            //Assert
            Assert.AreEqual(expectedCount, this.chainBlock.Count);

        }

        [Test]
        public void AddingExistingTransactionShouldThrowAnException()
        {

            //Arrange
            ITransaction transaction = new Transaction(1, TransactionStatus.Failed
                , "Pesho", "Gosho", 10);

            //Act
            this.chainBlock.Add(transaction);

            //Assert
            Assert.That(() =>
            {
                this.chainBlock.Add(transaction);
            },
            Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.AddingExistingTransactionMessage));

        }

        [Test]
        public void AddingSameTransactionWithAnotherIdShouldPass()
        {

            //Arrange
            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull
                , "Pesho", "Gosho", 10);
            ITransaction transactionCopy = new Transaction(2, TransactionStatus.Successfull
                , "Pesho", "Gosho", 10);
            int expectedCount = 2;
            //Act
            this.chainBlock.Add(transaction);
            this.chainBlock.Add(transactionCopy);

            //Assert
            Assert.AreEqual(expectedCount, this.chainBlock.Count);
        }

        [Test]
        public void ContainsShouldTrueWithExistingTr()
        {

            //Arrange
            ITransaction transaction = new Transaction(1, TransactionStatus.Failed
                , "Pesho", "Gosho", 10);

            //Act
            // this.chainBlock.Add(transaction);

            //Assert
            Assert.IsFalse(this.chainBlock.Contains(transaction));
        }

        [Test]
        public void ContainsShouldIdReturnFalseWhenNonExistingTransaction()
        {

            //Arrange
            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull
                , "Pesho", "Gosho", 10);

            //Act
            this.chainBlock.Add(transaction);

            //Assert
            Assert.IsTrue(this.chainBlock.Contains(transaction));
        }

        [Test]
        public void ContainsByIdShouldReturnTrueWithExistingTransaction()
        {
            //Arrange
            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull
                , "Pesho", "Gosho", 10);

            //Act
            this.chainBlock.Add(transaction);

            //Assert
            Assert.IsTrue(this.chainBlock.Contains(1));

        }

        [Test]
        public void ContainsByIdShouldReturnFalseWithNonExistingTransaction()
        {
            //Arrange
            ITransaction transaction = new Transaction(1, TransactionStatus.Failed
                , "Pesho", "Gosho", 10);

            //Act
            // this.chainBlock.Add(transaction);

            //Assert
            Assert.IsFalse(this.chainBlock.Contains(1));
        }

        [Test]
        public void ChangeTransactionStatusShouldSuccess()
        {
            //Arrange
            int id = 1;
            TransactionStatus transactionStatus = TransactionStatus.Unauthorized;
            string from = "Pesho";
            string to = "Gosho";
            double amount = 10;
            ITransaction transaction = new Transaction(id, transactionStatus, from, to, amount);
            TransactionStatus newStatus = TransactionStatus.Successfull;

            //Act
            this.chainBlock.Add(transaction);
            this.chainBlock.ChangeTransactionStatus(id, newStatus);

            //Assert
            Assert.AreEqual(newStatus, transaction.Status);
        }

        [Test]
        public void ChangingStatusOfNonExistingTransactionShouldIdThrowException()
        {
            //Arrange
            int id = 1;
            TransactionStatus transactionStatus = TransactionStatus.Unauthorized;
            string from = "Pesho";
            string to = "Gosho";
            double amount = 10;
            ITransaction transaction = new Transaction(id, transactionStatus, from, to, amount);
            TransactionStatus newStatus = TransactionStatus.Successfull;
            int fakeId = 13;
            //Act
            this.chainBlock.Add(transaction);
            this.chainBlock.ChangeTransactionStatus(id, newStatus);

            //Assert
            Assert.That(() =>
                        {
                            this.chainBlock.ChangeTransactionStatus(fakeId, newStatus);
                        }, Throws.ArgumentException
                        .With.Message.EqualTo(ExceptionMessages.ChangingStatusOfNonExistingTr));
        }

        [Test]
        public void GetByIdShouldBeReturnCorrectTransaction()
        {
            //Arrange
            int id = 2;
            TransactionStatus status = TransactionStatus.Successfull;
            string from = "Sender";
            string to = "Reciever";
            double amount = 20;
            ITransaction transaction = new Transaction(id, status, from, to, amount);

            //Act
            this.chainBlock.Add(this.transaction);
            this.chainBlock.Add(transaction);

            ITransaction returnedTransaction = this.chainBlock
                .GetById(id);

            //Assert
            Assert.AreEqual(transaction, returnedTransaction);

        }

        [Test]
        public void GetByIdShouldThrowAnExceptionWhenTryingToFindExistingTransaction()
        {
            //Arrange
            int id = 2;
            TransactionStatus status = TransactionStatus.Successfull;
            string from = "Sender";
            string to = "Reciever";
            double amount = 20;
            ITransaction transaction = new Transaction(id, status, from, to, amount);

            int fakeId = 13;

            //Act
            this.chainBlock.Add(this.transaction);
            this.chainBlock.Add(transaction);

            //Assert
            Assert.That(
                () =>
            {
                this.chainBlock.GetById(fakeId);
            }
             , Throws.InvalidOperationException.With.Message
             .EqualTo(ExceptionMessages.NonExistingTransactionMessage));

        }

        [Test]
        public void RemovingTRansactionShouldIdDecreaseCount()
        {
            //Arrange
            int id = 2;
            TransactionStatus status = TransactionStatus.Successfull;
            string from = "Pesho";
            string to = "Gosho";
            double amount = 250;

            ITransaction transaction = new Transaction(id, status, from, to, amount);

            //Act
            this.chainBlock.Add(this.transaction);
            this.chainBlock.Add(transaction);
            int expectedCount = 1;
            this.chainBlock.RemoveTransactionById(id);

            //Assert
            Assert.AreEqual(expectedCount, this.chainBlock.Count);

        }

        [Test]
        public void RemovingTransactionShouldPhysicallyRemoveTheTx()
        {
            //Arrange
            int id = 2;
            TransactionStatus status = TransactionStatus.Successfull;
            string from = "Pesho";
            string to = "Gosho";
            double amount = 250;

            ITransaction transaction = new Transaction(id, status, from, to, amount);

            //Act
            this.chainBlock.Add(this.transaction);
            this.chainBlock.Add(transaction);
            int expectedCount = 1;
            this.chainBlock.RemoveTransactionById(id);

            //Assert
            Assert.That(() =>
                     {
                         this.chainBlock.GetById(id);
                     }, Throws.InvalidOperationException.With.Message
                     .EqualTo(ExceptionMessages.NonExistingTransactionMessage));
        }

        [Test]
        public void RemoveNonExistingTransactionShouldIdThrowException()
        {
            //Arrange
            int id = 2;
            TransactionStatus status = TransactionStatus.Successfull;
            string from = "Pesho";
            string to = "Gosho";
            double amount = 250;
            int fakeId = 13;
            ITransaction transaction = new Transaction(id, status, from, to, amount);

            //Act
            this.chainBlock.Add(this.transaction);
            this.chainBlock.Add(transaction);
            int expectedCount = 1;

            //Assert
            Assert.That(() =>
                     {
                         this.chainBlock.RemoveTransactionById(fakeId);
                     },
                     Throws.InvalidOperationException.With.Message
                     .EqualTo(ExceptionMessages.RemovingNoneExistingMessage));
        }

        [Test]
        public void
            GetByTransactionStatusShouldReturnOrderedCollectionWithRightTransactions()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus status = (TransactionStatus)i;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10;
                ITransaction currentTr = new Transaction(id, status, from, to, amount);
                if (status == TransactionStatus.Successfull)
                {
                    expTransactions.Add(currentTr);
                }
                this.chainBlock.Add(currentTr);
            }
            ITransaction tr = new Transaction(5, TransactionStatus.Successfull, "Pesho4", "Gosho4", 15);
            expTransactions.Add(tr);
            this.chainBlock.Add(tr);

            IEnumerable<ITransaction> actTransactions = this.chainBlock
                                     .GetByTransactionStatus(TransactionStatus
                                     .Successfull);
            expTransactions = expTransactions
                .OrderByDescending(tx => tx.Amount)
                .ToList();

            CollectionAssert.AreEqual(expTransactions, actTransactions);
        }

        [Test]
        public void TestGettingTransactionsWithNoExistingStatus()
        {
            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus status = TransactionStatus.Failed;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10 * (i + 1 + 1);

                ITransaction crrTr = new Transaction(id, status, from, to, amount);
                this.chainBlock.Add(crrTr);
            }

            Assert.That(
              () =>
              {
                  this.chainBlock.GetByTransactionStatus(TransactionStatus.Successfull);
              }
              , Throws.InvalidOperationException.With.Message
              .EqualTo(ExceptionMessages.EmptyStatusTrCollectionMessage));
        }

        [Test]
        public void AllSendersByStatusShouldReturnCorrectOrderedCollection()
        {

            ICollection<ITransaction> expTransactions = new List<ITransaction>();
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus status = (TransactionStatus)i;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10;
                ITransaction currentTr = new Transaction(id, status, from, to, amount);
                if (status == TransactionStatus.Successfull)
                {
                    expTransactions.Add(currentTr);
                }
                this.chainBlock.Add(currentTr);
            }
            ITransaction tr = new Transaction(5, TransactionStatus.Successfull, "Pesho4", "Gosho4", 15);
            expTransactions.Add(tr);
            this.chainBlock.Add(tr);

            IEnumerable<string> actTransactions = this.chainBlock
                .GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);
            IEnumerable<string> expTr = expTransactions
             .OrderByDescending(tx => tx.Amount)
             .Select(tx => tx.From);
            CollectionAssert.AreEqual(expTr, actTransactions);
        }

        [Test]
        public void AllSendersByStatusShouldThrowAnExceptionWhenThereAreNotWithGivenStatus()
        {
            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus status = TransactionStatus.Failed;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10 * (i + 1 + 1);

                ITransaction crrTr = new Transaction(id, status, from, to, amount);
                this.chainBlock.Add(crrTr);
            }

            Assert.That(()
                => this.chainBlock
                .GetAllSendersWithTransactionStatus(TransactionStatus.Successfull)
                , Throws
                .InvalidOperationException.With.Message
                .EqualTo(ExceptionMessages.EmptyStatusTrCollectionMessage));
        }

        [Test]
        public void AllReciversByStatusShouldReturnCorrectOrderedCollection()
        {

            ICollection<ITransaction> expTransactions = new List<ITransaction>();
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus status = (TransactionStatus)i;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10;
                ITransaction currentTr = new Transaction(id, status, from, to, amount);
                if (status == TransactionStatus.Successfull)
                {
                    expTransactions.Add(currentTr);
                }
                this.chainBlock.Add(currentTr);
            }
            ITransaction tr = new Transaction(5, TransactionStatus.Successfull, "Pesho4", "Gosho4", 15);
            expTransactions.Add(tr);
            this.chainBlock.Add(tr);

            IEnumerable<string> actTransactions = this.chainBlock
                .GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);
            IEnumerable<string> expTr = expTransactions
             .OrderByDescending(tx => tx.Amount)
             .Select(tx => tx.To);
            CollectionAssert.AreEqual(expTr, actTransactions);
        }

        [Test]
        public void AllRecieversByStatusShouldThrowAnExceptionWhenThereAreNotWithGivenStatus()
        {
            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus status = TransactionStatus.Failed;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10 * (i + 1 + 1);

                ITransaction crrTr = new Transaction(id, status, from, to, amount);
                this.chainBlock.Add(crrTr);
            }

            Assert.That(()
                => this.chainBlock
                .GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull)
                , Throws
                .InvalidOperationException.With.Message
                .EqualTo(ExceptionMessages.EmptyStatusTrCollectionMessage));
        }

        [Test]
        public void TestGetAllOrderedByAmountThenByIdWithNoDublicatedAmounts()
        {
            ICollection<ITransaction> expTranzactions = new List<ITransaction>();
            for (int i = 0; i < 10; i++)
            {
                int id = (i + 1);
                TransactionStatus status = (TransactionStatus)(i % 4);
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10 + 1;
                ITransaction currTr = new Transaction(id, status, from, to, amount);
                this.chainBlock.Add(currTr);
                expTranzactions.Add(currTr);
            }
            IEnumerable<ITransaction> actTransaction = this.chainBlock
                .GetAllOrderedByAmountDescendingThenById();

            expTranzactions = expTranzactions
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id).ToList();
            CollectionAssert.AreEqual(expTranzactions, actTransaction);
        }

        [Test]
        public void TestGetAllOrderedByAmountThenByIdWithDublicatedAmount()
        {

            ICollection<ITransaction> expTranzactions = new List<ITransaction>();
            for (int i = 0; i < 10; i++)
            {
                int id = (i + 1);
                TransactionStatus status = (TransactionStatus)(i % 4);
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10 + 1;
                ITransaction currTr = new Transaction(id, status, from, to, amount);
                this.chainBlock.Add(currTr);
                expTranzactions.Add(currTr);
            }

            ITransaction transaction = new Transaction(11, TransactionStatus.Successfull, "Gosho11", "Pesho11", 10);
            this.chainBlock.Add(transaction);
            expTranzactions.Add(transaction);

            IEnumerable<ITransaction> actTransaction = this.chainBlock
                .GetAllOrderedByAmountDescendingThenById();

            expTranzactions = expTranzactions
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id).ToList();
            CollectionAssert.AreEqual(expTranzactions, actTransaction);
        }

        [Test]
        public void TestGetAllOrderedByAmountThenByIdWithEmptyCollection()
        {
            ICollection<ITransaction> expTr = new List<ITransaction>();
            IEnumerable<ITransaction> actTr
                = this.chainBlock.GetAllOrderedByAmountDescendingThenById();

            CollectionAssert.IsEmpty(actTr);
        }

        [Test]
        public void TestIfGetAllBySenderDescendingByAmountShouldWorksCorrect()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();
            string wantedSender = "Pesho";
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus status = TransactionStatus.Successfull;
                string from = wantedSender;
                string to = "Gosho" + i;
                double amount = 10 + i;
                ITransaction currTr = new Transaction(id, status, from, to, amount);
                expTransactions.Add(currTr);
                this.chainBlock.Add(currTr);

            }
            for (int i = 4; i < 10; i++)
            {

                int id = i + 1;
                TransactionStatus status = TransactionStatus.Successfull;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 20 + i;
                ITransaction currTr = new Transaction(id, status, from, to, amount);
                this.chainBlock.Add(currTr);
            }

            IEnumerable<ITransaction> actTr = this.chainBlock
                .GetBySenderOrderedByAmountDescending(wantedSender);
            expTransactions = expTransactions
                .OrderByDescending(tx => tx.Amount)
                .ToList();

            CollectionAssert.AreEqual(expTransactions, actTr);
        }

        [Test]
        public void TestGetAllByNonExistingSenderDescendingByAmount()
        {
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus status = TransactionStatus.Successfull;
                string from = "Pesho" + i; ;
                string to = "Gosho" + i;
                double amount = 10 + i;
                ITransaction currTr = new Transaction(id, status, from, to, amount);
                this.chainBlock.Add(currTr);

            }
            string wantedSender = "Pesho";
            Assert.That(() =>
            {
                this.chainBlock
                .GetBySenderOrderedByAmountDescending(wantedSender);
            }
            , Throws.InvalidOperationException.With.Message
            .EqualTo(ExceptionMessages.NoTransactionForGivenSenderMessage));
        }

        [Test]
        public void TestIffetByRecieverDescendingByAmountThenByWorksCorrectlyWithNoDublicatedAmounts
            ()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();
            string wantedReciever = "Pesho";
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus status = TransactionStatus.Successfull;
                string from = "Pesho" + i;
                string to = wantedReciever;
                double amount = 10 + i;
                ITransaction currTr = new Transaction(id, status, from, to, amount);
                expTransactions.Add(currTr);
                this.chainBlock.Add(currTr);

            }

            for (int i = 4; i < 10; i++)
            {

                int id = i + 1;
                TransactionStatus status = TransactionStatus.Successfull;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 20 + i;
                ITransaction currTr = new Transaction(id, status, from, to, amount);
                this.chainBlock.Add(currTr);
            }
            IEnumerable<ITransaction> actTr
                = this.chainBlock.GetByReceiverOrderedByAmountThenById(wantedReciever);
            expTransactions = expTransactions
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id)
                .ToList();
            CollectionAssert.AreEqual(expTransactions, actTr);
        }

        [Test]
        public void TestIffetByRecieverDescendingByAmountThenByWorksCorrectlyWithDublicatedAmounts
            ()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();
            string wantedReciever = "Pesho";
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus status = TransactionStatus.Successfull;
                string from = "Pesho" + i;
                string to = wantedReciever;
                double amount = 10 + i;
                ITransaction currTr = new Transaction(id, status, from, to, amount);
                expTransactions.Add(currTr);
                this.chainBlock.Add(currTr);

            }

            for (int i = 4; i < 10; i++)
            {

                int id = i + 1;
                TransactionStatus status = TransactionStatus.Successfull;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 20 + i;
                ITransaction currTr = new Transaction(id, status, from, to, amount);
                this.chainBlock.Add(currTr);
            }
            ITransaction tr = new Transaction(11, TransactionStatus.Successfull,
                "Pesho11", wantedReciever, 10);
            IEnumerable<ITransaction> actTr
                = this.chainBlock.GetByReceiverOrderedByAmountThenById(wantedReciever);
            expTransactions = expTransactions
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id)
                .ToList();
            CollectionAssert.AreEqual(expTransactions, actTr);
        }

        [Test]
        public void GetByRecieverDescendingByAmountThenByIdShouldThrowException()
        {
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus status = TransactionStatus.Successfull;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10 + i;
                ITransaction currTr = new Transaction(id, status, from, to, amount);
                this.chainBlock.Add(currTr);

            }
            string wantedReciver = "Gosho";
            Assert.That(() =>
            {
                this.chainBlock
                .GetByReceiverOrderedByAmountThenById(wantedReciver);
            },
            Throws.InvalidOperationException.With.Message
            .EqualTo(ExceptionMessages
            .NoTransactionForGivenRecieverMessage));
        }

        [Test]
        public void GetByReceiverInRangeShouldReturnFilterTransactions()
        {
            var recieverName = "Peter";
            for (int i = 1; i <= 100; i++)
            {
                TransactionStatus status = (TransactionStatus)(i % 4);
                var reciever = i % 2 == 0 ? recieverName : i.ToString();
                var tx = new Transaction(i, status, "Pesho", reciever, i * 50);
                this.chainBlock.Add(tx);
            }
            var filtered = this.chainBlock.GetByReceiverAndAmountRange(recieverName,50,90);

            double amount = double.MaxValue;
            foreach (var tx in filtered)
            {
                Assert.That(tx.Amount, Is.LessThan(amount),);
                amount = tx.Amount;
            }
        }

        [Test]
        public void ChainBlockEnumarator()
        {
            ICollection<ITransaction> expecTr = new List<ITransaction>();
            ICollection<ITransaction> actTr = new List<ITransaction>();
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus status = TransactionStatus.Successfull;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10 + i;
                ITransaction currTr = new Transaction(id, status, from, to, amount);
                expecTr.Add(currTr);
                this.chainBlock.Add(currTr);

            }
            foreach (ITransaction transaction in this.chainBlock)
            {
                actTr.Add(transaction);
            }
            CollectionAssert.AreEqual(expecTr, actTr);
        }
    }
}
