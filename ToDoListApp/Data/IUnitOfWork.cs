using ToDoListApp.Data.Repositories;

namespace ToDoListApp.Data
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IToDoRepository ToDoRepository { get; }
        Task CommitAsync();
    }

}
