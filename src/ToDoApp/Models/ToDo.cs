namespace ToDoApp.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool Completed { get; set; } = false;
    }
}