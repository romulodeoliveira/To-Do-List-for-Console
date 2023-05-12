using System.Data.SQLite;

namespace ToDoApp.Data
{
    public class DatabaseConfig
    {
        private const string DatabaseFileName = "database.db";

        public SQLiteConnection GetConnection()
        {
            string connectionString = $"Data Source={DatabaseFileName}";

            var connection = new SQLiteConnection(connectionString);
            connection.Open();

            CreateTasksTable(connection);

            return connection;

            // O método GetConnection() retorna uma instância de SQLiteConnection. A string de conexão é criada usando a constante DatabaseFileName, que define o nome do arquivo do banco de dados.
        }

        private void CreateTasksTable(SQLiteConnection connection)
        {
            string createTableQuery = "CREATE TABLE IF NOT EXISTS Tasks (Id INTEGER PRIMARY KEY AUTOINCREMENT, Description TEXT, Completed INTEGER);";

            using (var command = new SQLiteCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}