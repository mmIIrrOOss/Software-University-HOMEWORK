namespace Chainblock.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using ExceptionMessages;

    public class ChainBlock : IChainblock
    {
        private ICollection<ITransaction> transactions;

        public ChainBlock()
        {
            this.transactions = new List<ITransaction>();
        }

        public int Count => this.transactions.Count;

        public void Add(ITransaction tx)
        {
            if (this.Contains(tx))
            {
                throw new InvalidOperationException(ExceptionMessages.AddingExistingTransactionMessage);
            }
            this.transactions.Add(tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            ITransaction transaction = this.transactions
                .FirstOrDefault(tx => tx.Id == id);

            if (transaction == null)
            {
                throw new ArgumentException(ExceptionMessages.ChangingStatusOfNonExistingTr);
            }

            transaction.Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            return this.Contains(tx.Id);
        }

        public bool Contains(int id)
        {
            bool isContained = this.transactions.Any(tx => tx.Id == id);
            return isContained;
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            IEnumerable<ITransaction> transactions =
                this.transactions
                .OrderByDescending(tr => tr.Amount)
                .ThenBy(tr => tr.Id);

            return transactions;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> recivers = this.GetByTransactionStatus(status)
                .Select(tx => tx.To);
            return recivers;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> senders = this
                .GetByTransactionStatus(status)
                .Select(tx=>tx.From);
            return senders;
        }

        public ITransaction GetById(int id)
        {
            ITransaction transaction = this.transactions
                .FirstOrDefault(tx => tx.Id == id);
            if (transaction == null)
            {
                throw new InvalidOperationException(ExceptionMessages
                    .NonExistingTransactionMessage);
            }
            return transaction;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            IEnumerable<ITransaction> transactions = this.transactions
                .Where(tx => tx.To == receiver)
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id);
            if (transactions.Count() == 0)
            {
                throw new InvalidOperationException(ExceptionMessages
                    .NoTransactionForGivenRecieverMessage);
            }
            return transactions;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            IEnumerable <ITransaction> transactions = this.transactions
                .Where(tx => tx.From == sender)
                .OrderByDescending(tx => tx.Amount);
            if (transactions.Count()==0)
            {
                throw new InvalidOperationException
                    (ExceptionMessages
                    .NoTransactionForGivenSenderMessage);
            }
            return transactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            IEnumerable<ITransaction> transactions = this.transactions
                .Where(tr => tr.Status == status)
                .OrderByDescending(tr=>tr.Amount);
            if (transactions.Count()==0)
            {
                throw new InvalidOperationException(ExceptionMessages
                    .EmptyStatusTrCollectionMessage);
            }
            return transactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.transactions.ToArray()[i];
            }
        }

        public void RemoveTransactionById(int id)
        {
            try
            {
                ITransaction transaction = this.GetById(id);
                this.transactions.Remove(transaction);
            }
            catch (InvalidOperationException ioe)
            {
                throw new InvalidOperationException(
                    ExceptionMessages.RemovingNoneExistingMessage,ioe);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
