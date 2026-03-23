using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ToDoListApp.Utils
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _set;
        protected Repository(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public async Task CreateAsync(T entity)=> await _set.AddAsync(entity);

        public async Task DeleteAsync(T entity)=> await Task.Run(() => _set.Remove(entity));


        public async Task<T?> FindByIdAsync(object id)=>await _set.FindAsync(id);


        public async Task<IEnumerable<T>> ReadManyAsync(Expression<Func<T, bool>>? expression = null, params string[] includes)
        {
           var data = expression == null ? _set : _set.Where(expression);
            foreach (string include in includes)
            {
                data = data.Include(include);
            }
            return await data.ToListAsync();    
        }

        public async Task UpdateAsync(T entity)=> await Task.Run(() => _set.Update(entity));

    }
}
