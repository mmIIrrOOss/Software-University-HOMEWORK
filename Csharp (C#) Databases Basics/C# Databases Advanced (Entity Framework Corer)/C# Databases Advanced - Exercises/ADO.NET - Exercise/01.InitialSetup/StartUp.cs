namespace _01.InitialSetup
{

    using System.Data.SqlClient;
    using System.IO;

    class StartUp
    {
        private const string DBName = "master";
        private const string ServerName = ".";
        private const string Authentication = "Integrated Security=true";

        static void Main(string[] args)
        {
            CreateDatabase(DBName, ServerName, Authentication);

            string connectionString = $@"
                Server={ServerName}; 
                Database={DBName}; 
                {Authentication};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string cmdText = File.ReadAllText(@"../../../InitialSetup.sql");
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void CreateDatabase(string dBName, string serverName, string authentication)
        {
            string connectionString = $@"Server={serverName};
                                         Database={dBName};
                                         {authentication};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string createDatabaseQuery = "CREATE DATABASE MinionsDB";
                using (SqlCommand command = new SqlCommand(createDatabaseQuery,connection))
                {
                    command.ExecuteNonQuery();
                }

            }
        }
    }
}
