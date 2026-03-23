namespace ToDoListApp.BusinessLogic.Dtos
{
    public class ToDoDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public bool Done { get; set; }= false;
    }
}
