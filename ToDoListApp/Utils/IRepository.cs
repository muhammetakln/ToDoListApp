using System.Linq.Expressions;

namespace ToDoListApp.Utils
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<T?> FindByIdAsync(object id);
        Task<IEnumerable<T>> ReadManyAsync(Expression<Func<T, bool>>?expression = null, params string[] includes);
        Task  UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
