namespace Chainblock.Models
{
    using Contracts;

    using ExceptionMessages;
    using System;

    public class Transaction : ITransaction
    {
        private const int MIN_ID_VALUE = 0;
        private const int MIN_Amount_VALUE = 0;
        private int id;
        private TransactionStatus transactionStatus;
        private string from;
        private string to;
        private double amount;

        public Transaction(int id, TransactionStatus transactionStatus,
            string from, string to, double amount)
        {
            this.Id = id;
            this.Status = transactionStatus;
            this.From = from;
            this.To = to;
            this.Amount = amount;
        }

        public int Id
        {
            get => this.id;
            set
            {
                if (value <= MIN_ID_VALUE)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidIdMessage);
                }
                this.id = value;
            }
        }

        public TransactionStatus Status
        {
            get => this.transactionStatus;
            set
            {
                this.transactionStatus = value;
            }
        }

        public string From
        {
            get => this.from;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidSenderUsernameMessage);
                }
                this.from = value;
            }
        }

        public string To
        {
            get => this.to;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidReciverUsernameMessage);
                }
                this.to = value;
            }
        }

        public double Amount
        {
            get => this.amount;
            set
            {
                if (value <= MIN_Amount_VALUE)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTransactionAmauntMessage);
                }
                this.amount = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is ITransaction transaction)
            {
                return this.Id == transaction.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
