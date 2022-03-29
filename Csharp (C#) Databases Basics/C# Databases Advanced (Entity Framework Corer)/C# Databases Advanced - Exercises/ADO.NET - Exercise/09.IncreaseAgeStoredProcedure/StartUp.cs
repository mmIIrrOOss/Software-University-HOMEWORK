namespace _09.IncreaseAgeStoredProcedure
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;

    class StartUp
    {
        private const string DBName = "master";
        private const string ServerName = ".";
        private const string Authentication = "Integrated Security=true";

        private const string GetOlderProcedureCreationQueryPath = @"..\..\GetOlder-Procedure.sql";
        private const string MinionSelectionQueryQueryPath = @"..\..\Select-Minion-Query.sql";

        public static string ConnectionString = $@"
                Server={ServerName}; 
                Database={DBName}; 
                {Authentication};";

        static void Main(string[] args)
        {
            //CreateGetOlderProcedure();
            Console.Write("Enter Minion Id: ");
            int minionId = int.Parse(Console.ReadLine());
            UseGetOlderProcedure(minionId);
        }
        private static void UseGetOlderProcedure(int minionId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("usp_GetOlder", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@minionId", minionId);
                    command.ExecuteNonQuery();
                }

                string cmdText = File.ReadAllText(MinionSelectionQueryQueryPath);
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("@minionId", minionId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write($"{reader[i]} ");
                            }
                        }
                    }
                }
            }
        }

        private static void CreateGetOlderProcedure()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string cmdText = File.ReadAllText(GetOlderProcedureCreationQueryPath);
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
