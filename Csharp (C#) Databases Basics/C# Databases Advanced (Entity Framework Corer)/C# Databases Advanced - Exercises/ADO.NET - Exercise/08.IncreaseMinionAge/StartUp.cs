namespace _08.IncreaseMinionAge
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;

    class StartUp
    {
        private const string DBName = "master";
        private const string ServerName = ".";
        private const string Authentication = "Integrated Security=true";

        private const string MinionsNamesToTilteAndAgePlusOneQueryPath = @"../../../Increase-Minion-Age.sql";

        public static string ConnectionString = $@"
                Server={ServerName}; 
                Database={DBName}; 
                {Authentication};";

        static void Main(string[] args)
        {
            IEnumerable<int> minionsIds = Console.ReadLine()
                .Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string cmdText = File.ReadAllText(MinionsNamesToTilteAndAgePlusOneQueryPath)
                    .Replace("@idCollection", string.Join(", ", minionsIds));
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Affected rows: {rowsAffected}");
                }
            }
        }
    }
}
