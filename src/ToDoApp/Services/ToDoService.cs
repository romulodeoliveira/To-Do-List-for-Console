using ToDoApp.Data;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public class ToDoService
    {
        private readonly ToDoRepository _toDoRepository;

        public ToDoService(ToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public IEnumerable<ToDo> GetAllTasks()
        {
            return _toDoRepository.GetAllTasks();
        }

        public void AddTask(ToDo task)
        {
            _toDoRepository.AddTask(task);
        }

        public void UpdateTask(ToDo task)
        {
            _toDoRepository.UpdateTask(task);
        }

        public void DeleteTask(int taskId)
        {
            _toDoRepository.DeleteTask(taskId);
        }

    }
}