using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using ToDoListApp.Data.Entities;

namespace ToDoListApp.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }
        public virtual DbSet<ToDo> ToDos { get; set; }


    }

}
