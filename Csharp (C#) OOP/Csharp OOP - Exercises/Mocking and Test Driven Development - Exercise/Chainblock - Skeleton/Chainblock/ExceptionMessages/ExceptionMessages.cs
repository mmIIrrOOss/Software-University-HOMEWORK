namespace Chainblock.ExceptionMessages
{
    using System;

    public static class ExceptionMessages
    {
        public static string InvalidIdMessage 
            = "IDs cannot be zero or negative!.";

        public static string InvalidSenderUsernameMessage
            = "Sender cannot be empty or whitespace!";

        public static string InvalidReciverUsernameMessage
            = "Reciver cannot be empty or whitespace!";

        public static string InvalidTransactionAmauntMessage
            = "Transaction amount should be greater than zero!";

        public static string AddingExistingTransactionMessage
            = "Transaction already exists in our rexcords!";

        public static string ChangingStatusOfNonExistingTr
            = "You can t change the status of non existing transaction!";

        public static string NonExistingTransactionMessage
             = "Transaction with given id not Found!";

        public static string RemovingNoneExistingMessage
            = "You cannot non existing transaction!";

        public static string EmptyStatusTrCollectionMessage
             = "There are not transactions matching provided transactionstatus!";

        public static string NoTransactionForGivenSenderMessage
            = "There are no coresponding transactions to given sender name";

        public static string NoTransactionForGivenRecieverMessage
            = "There are no coresponding transactions to given reciever name";

        public static string FilteredTransactionByAmount
             = "Filtered transaction should be ordered by amount in descending order.";
    }
}
