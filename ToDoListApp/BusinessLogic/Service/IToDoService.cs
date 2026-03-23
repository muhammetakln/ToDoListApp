using ToDoListApp.BusinessLogic.Dtos;
using ToDoListApp.Data.Repositories;

namespace ToDoListApp.BusinessLogic.Service
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDoDto>> GetAll();
        Task<ToDoDto?> GetByIdAsync(int id);
        Task NewAsync(string content);
        Task UpdateAsync(string content);
        Task DeleteAsync(int id);
        Task ToggleAsync(int id);
    }
}
