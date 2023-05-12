/**
Referencia ao pacote SQLite:

$ dotnet add package System.Data.SQLite
https://www.nuget.org/packages/System.Data.SQLite
*/

using System;
using System.Data.SQLite;

namespace ToDoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Estabelecendo a conexão com o banco de dados:
            using (var connection = new SQLiteConnection("Data Source=database.db;"))
            {

            }
        }
    }
}