namespace _07.PrintAllMinionNames
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

        private const string MinionsNamesSelectionQueryPath = @"..\..\SQL-Queries\Select-MinionNames-Query.sql";

        public static string ConnectionString = $@"
                Server={ServerName}; 
                Database={DBName}; 
                {Authentication};";

        static void Main(string[] args)
        {
            IEnumerable<string> allMinionsNames = GetAllMinionNames();
            PrintNamesInSpecialOrder(allMinionsNames.ToArray());
        }

        private static void PrintNamesInSpecialOrder(string[] minionsNames)
        {
            for (int first = 0, last = minionsNames.Length - 1; first <= last; first++, last--)
            {
                Console.WriteLine(minionsNames[first]);
                if (first != last)
                {
                    Console.WriteLine(minionsNames[last]);
                }
            }
        }

        private static IEnumerable<string> GetAllMinionNames()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string cmdText = File.ReadAllText(MinionsNamesSelectionQueryPath);
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.GetString(0);
                        }
                    }
                }
            }
        }
    }
}
