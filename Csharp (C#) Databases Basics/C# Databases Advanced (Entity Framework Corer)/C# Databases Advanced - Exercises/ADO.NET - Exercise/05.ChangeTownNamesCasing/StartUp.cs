namespace _05.ChangeTownNamesCasing
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;

    class StartUp
    {
        private const string DBName = "master";
        private const string ServerName = ".";
        private const string Authentication = "Integrated Security=true";

        private const string UpdateTownsNamesByCountryQueryPath = @"..\..\Update-Towns.sql";
        private const string SelectTownsByCountryQueryPath = @"..\..\Select-Towns-Query.sql";

        public static string ConnectionString = $@"
                Server={ServerName}; 
                Database={DBName}; 
                {Authentication};";

        static void Main(string[] args)
        {

            Console.Write("Enter a country name: ");
            string countryName = Console.ReadLine();

            if (!TryMakeTownsToUpper(countryName))
            {
                Console.WriteLine("No town names were affected.");
            }

        }

        private static bool TryMakeTownsToUpper(string countryName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string cmdText = File.ReadAllText(UpdateTownsNamesByCountryQueryPath);
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);
                    int numberOfAffectedRows = command.ExecuteNonQuery();
                    if (numberOfAffectedRows == 0)
                    {
                        return false;
                    }
                }

                PrintTownsByCountry(countryName, connection);
            }

            return true;
        }

        private static void PrintTownsByCountry(string countryName, SqlConnection connection)
        {
            string cmdText = File.ReadAllText(SelectTownsByCountryQueryPath);
            using (SqlCommand command = new SqlCommand(cmdText, connection))
            {
                command.Parameters.AddWithValue("@countryName", countryName);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    IEnumerable<string> townsNames = ReaderToCollection(reader, 0);
                    Console.WriteLine($"[{string.Join(", ", townsNames)}]");
                }
            }
        }

        private static IEnumerable<string> ReaderToCollection(SqlDataReader reader, int columnIndex)
        {
            while (reader.Read())
            {
                yield return reader.GetString(columnIndex);
            }
        }
    }
}
