using System.Data.SqlClient;

namespace Users.Data
{
    public static class ConnectionManager
    {
        // TODO - keep in configuration file
        private const string ConnectionString = "Data Source=.; Initial Catalog=week14;Integrated Security=True;";

        private static SqlConnection _connection;

        public static SqlConnection GetConnection()
        {
            if (_connection != null)
            {
                return _connection;
            }

            _connection = new SqlConnection
            {
                ConnectionString = ConnectionString
            };

            _connection.Open();

            return _connection;
        }
    }
}