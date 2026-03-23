using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Data.Entities
{
    public class ToDo
    {
        public int Id { get; set; }
        [Required,MaxLength(500)]
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public bool Done { get; set; } = false;


    }
}
