using ToDoListApp.Data.Repositories;

namespace ToDoListApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ToDoContext context;
        public UnitOfWork(ToDoContext context)
        {
            this.context = context;
        }
        private IToDoRepository? toDoRepository;
        public IToDoRepository ToDoRepository => toDoRepository ??= new ToDoRepository(context);

        public async Task CommitAsync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async ValueTask DisposeAsync()
        {
            await context.DisposeAsync();
        }
    }

}
