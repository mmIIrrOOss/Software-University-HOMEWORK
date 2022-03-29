namespace _06.Remove_Villain
{
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Transactions;

    class StartUp
    {
        private const string DBName = "master";
        private const string ServerName = ".";
        private const string Authentication = "Integrated Security=true";

        private const string MinionsVillainsDeletionQueryPath = @"..\..\SQL-Queries\Delete-MInionVillion-Query.sql";
        private const string VillainNameSelectionQueryPath = @"..\..\SQL-Queries\Select-Villain-Query.sql";
        private const string VillainDeleteByIdQueryPath = @"..\..\SQL-Queries\Delete-Villain-By-Id.sql";

        public static string ConnectionString = $@"
                Server={ServerName}; 
                Database={DBName}; 
                {Authentication};";

        private const string WrongIdMessage = "No such villain was found";

        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());
            int numberOfReleasedMinions = 0;
            string villainName = string.Empty;

            using (TransactionScope transaction = new TransactionScope())
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string villainNameSelectionCmdText = File.ReadAllText(VillainNameSelectionQueryPath);
                    using (SqlCommand command = new SqlCommand(villainNameSelectionCmdText, connection))
                    {
                        command.Parameters.AddWithValue("@villainId", villainId);
                        villainName = (string)command.ExecuteScalar();
                        if (string.IsNullOrEmpty(villainName))
                        {
                            Console.WriteLine(WrongIdMessage);
                            return;
                        }
                    }

                    string minionsVillainsDelCmdText = File.ReadAllText(MinionsVillainsDeletionQueryPath);
                    using (SqlCommand command = new SqlCommand(minionsVillainsDelCmdText, connection))
                    {
                        command.Parameters.AddWithValue("@villainId", villainId);
                        numberOfReleasedMinions = command.ExecuteNonQuery();
                    }

                    string villainDeletionCmdText = File.ReadAllText(VillainDeleteByIdQueryPath);
                    using (SqlCommand command = new SqlCommand(villainDeletionCmdText, connection))
                    {
                        command.Parameters.AddWithValue("@villainId", villainId);
                        command.ExecuteNonQuery();
                    }
                }

                transaction.Complete();
            }

            Console.WriteLine($"{villainName} was deleted");
            Console.WriteLine($"{numberOfReleasedMinions} minions released");

        }
    }
}
