using ToDoListApp.BusinessLogic.Dtos;
using ToDoListApp.Data.Repositories;

namespace ToDoListApp.BusinessLogic.Service
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDoDto>> GetAllAsync();
        Task<ToDoDto?> GetByIdAsync(int id);
        Task NewAsync(string content);
        Task UpdateAsync(int id , string content);
        Task DeleteAsync(int id);
        Task ToggleAsync(int id);
        
    }
}
