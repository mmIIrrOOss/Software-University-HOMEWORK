namespace _03.Minion_Names
{
    using System;
    using System.Data.SqlClient;
    using System.IO;

    class StartUp
    {
        private const string DBName = "master";
        private const string ServerName = ".";
        private const string Authentication = "Integrated Security=true";

        static void Main(string[] args)
        {
            string connectionString = $@"
                Server={ServerName}; 
                Database={DBName}; 
                {Authentication};";

            Console.Write("Enter a Villain ID: ");
            int villainId = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = string.Format(File.ReadAllText("../../../03.MinionNames.sql"), villainId);
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("@villainId", villainId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ProcessSelection(reader, villainId);
                    }
                }
            }
        }
        private static void ProcessSelection(SqlDataReader reader, int villainId)
        {
            if (reader.HasRows)
            {
                reader.Read();
                Console.WriteLine($"Villain: {reader["VillainName"]}");

                if (reader.IsDBNull(1))
                {
                    Console.WriteLine("(no minions)");
                }
                else
                {
                    int minionNumber = 1;
                    while (true)
                    {
                        Console.WriteLine($"{minionNumber++}. {reader["MinionName"]} {reader["MinionAge"]}");

                        if (!reader.Read())
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
            }
        }
    }
}
