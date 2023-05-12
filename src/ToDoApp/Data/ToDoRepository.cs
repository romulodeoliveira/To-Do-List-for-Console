using Dapper;
using ToDoApp.Models;

namespace ToDoApp.Data
{
    public class ToDoRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        /** Injeção de Dependência
        Ao receber o objeto DatabaseConfig no construtor, a classe ToDoRepository pode acessar as configurações do banco de dados necessárias para se conectar, executar consultas etc.
        Essa separação de responsabilidades permite que o código seja mais flexível e modular, pois o ToDoRepository não precisa se preocupar em como obter as configurações do banco de dados, apenas utiliza as configurações fornecidas.
        */

        public ToDoRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public IEnumerable<ToDo> GetAllTasks()
        {
            using (var connection = _databaseConfig.GetConnection())
            {
                string query = "SELECT * FROM Tasks";
                return connection.Query<ToDo>(query);
            }
        }

        public void AddTask(ToDo task)
        {
            using (var connection = _databaseConfig.GetConnection())
            {
                string query = "INSERT INTO Tasks (Name, Description, Completed) VALUES (@Name, @Description, @Completed)";
                connection.Execute(query, task);
            }
        }

        public void UpdateTask(ToDo task)
        {
            using (var connection = _databaseConfig.GetConnection())
            {
                string query = "UPDATE Tasks SET Name = @Name, Description = @Description, Completed = @Completed WHERE Id = @Id";
                connection.Execute(query, task);
            }
        }

        public void DeleteTask(int taskId)
        {
            using (var connection = _databaseConfig.GetConnection())
            {
                string query = "DELETE FROM Tasks WHERE Id = @Id";
                connection.Execute(query, new { Id = taskId });
            }
        }
    }
}