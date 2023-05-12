/**

-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

Referencia ao pacote SQLite:

$ dotnet add package System.Data.SQLite
https://www.nuget.org/packages/System.Data.SQLite

-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

Referencia ao pacote Dapper:

$ dotnet add package Dapper
https://www.nuget.org/packages/Dapper
O Dapper é uma biblioteca de mapeamento objeto-relacional (ORM) para o .NET.

-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

*/

using System;
using ToDoApp.Services;
using ToDoApp.Models;
using ToDoApp.Data;

namespace ToDoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var databaseConfig = new DatabaseConfig();
            var todoRepository = new ToDoRepository(databaseConfig);
            var toDoService = new ToDoService(todoRepository);

            bool sair = false;

            while (!sair)
            {
                Console.Clear();
                Console.WriteLine("[ 1 ] - Listar");
                Console.WriteLine("[ 2 ] - Adicionar");
                Console.WriteLine("[ 3 ] - Editar");
                Console.WriteLine("[ 4 ] - Deletar");
                Console.WriteLine("[ 0 ] - Sair");
                Console.WriteLine();
                Console.Write("Digite o número da opção desejada: ");
                string opcao = Console.ReadLine();

                if (opcao == "1")
                {
                    ToListTask(toDoService);
                }
                else if (opcao == "2")
                {
                    ToAddTask(toDoService);
                }
                else if (opcao == "3")
                {
                    ToUpdateTask(toDoService);
                }
                else if (opcao == "4")
                {
                    ToDeleteTask(toDoService);
                }
                else if (opcao == "0")
                {
                    sair = true;
                }
                else
                {
                    Console.WriteLine("Opção inválida. Digite um número válido.");
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }


            static void ToListTask(ToDoService toDoService)
            {
                Console.WriteLine("Listagem de tarefas:");

                var tasks = toDoService.GetAllTasks();

                if (tasks.Any())
                {
                    // Obter a largura máxima de cada coluna
                    int idWidth = Math.Max(2, tasks.Max(t => t.Id.ToString().Length));
                    int nameWidth = Math.Max(4, tasks.Max(t => t.Name.Length));
                    int descriptionWidth = Math.Max(11, tasks.Max(t => t.Description.Length));
                    int completedWidth = Math.Max(9, "Completed".Length);

                    // Imprimir cabeçalho da tabela
                    PrintLine(idWidth, nameWidth, descriptionWidth, completedWidth);
                    Console.WriteLine($"| {"ID".PadRight(idWidth)} | {"Nome".PadRight(nameWidth)} | {"Descrição".PadRight(descriptionWidth)} | {"Completo".PadRight(completedWidth)} |");
                    PrintLine(idWidth, nameWidth, descriptionWidth, completedWidth);

                    // Imprimir as tarefas
                    foreach (var task in tasks)
                    {
                        Console.WriteLine($"| {task.Id.ToString().PadRight(idWidth)} | {task.Name.PadRight(nameWidth)} | {task.Description.PadRight(descriptionWidth)} | {task.Completed.ToString().PadRight(completedWidth)} |");
                    }

                    // Imprimir linha inferior da tabela
                    PrintLine(idWidth, nameWidth, descriptionWidth, completedWidth);
                }
                else
                {
                    Console.WriteLine("Nenhuma tarefa encontrada.");
                }

                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }

            static void PrintLine(params int[] widths)
            {
                Console.WriteLine(new string('-', widths.Sum() + (widths.Length * 3) + 1));
            }


            static void ToAddTask(ToDoService todoService)
            {
                Console.WriteLine("Adicionar nova tarefa:");

                Console.Write("Digite o nome da tarefa: ");
                string name = Console.ReadLine();

                Console.Write("Digite a descrição da tarefa: ");
                string description = Console.ReadLine();

                ToDo task = new ToDo { Name = name, Description = description };
                todoService.AddTask(task);

                Console.WriteLine("Tarefa adicionada com sucesso!");
            }

            static void ToUpdateTask(ToDoService toDoService)
            {
                Console.Write("Digite o ID da tarefa que deseja editar: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Digite o novo nome da tarefa: ");
                string name = Console.ReadLine();

                Console.Write("Digite a nova descrição da tarefa: ");
                string description = Console.ReadLine();

                ToDo tarefa = new ToDo { Id = id, Name = name, Description = description };

                toDoService.UpdateTask(tarefa);

                Console.WriteLine("Tarefa atualizada com sucesso!");
            }

            static void ToDeleteTask(ToDoService toDoService)
            {
                Console.Write("Digite o ID da tarefa que deseja deletar: ");
                int id = int.Parse(Console.ReadLine());

                toDoService.DeleteTask(id);

                Console.WriteLine("Tarefa deletada com sucesso!");
            }
        }
    }
}
