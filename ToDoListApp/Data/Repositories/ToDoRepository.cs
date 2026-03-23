using ToDoListApp.Data.Entities;
using ToDoListApp.Utils;

namespace ToDoListApp.Data.Repositories
{
    public class ToDoRepository: Repository<ToDo>, IToDoRepository
    {
        public ToDoRepository(ToDoContext context) : base(context)
        {
        }
    }
}
