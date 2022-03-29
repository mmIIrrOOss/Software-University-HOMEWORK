namespace _02.VillainNames
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

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = File.ReadAllText(@"../../../VillainNames.sql");
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write($"{reader.GetName(i),-20}");
                            }

                            Console.WriteLine();

                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.Write($"{reader[i],-20}");
                                }

                                Console.WriteLine();
                            }
                        }
                    }
                }

            }
        }
    }
}
