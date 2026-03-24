using ToDoListApp.BusinessLogic.Dtos;
using ToDoListApp.Data;
using ToDoListApp.Data.Entities;

namespace ToDoListApp.BusinessLogic.Service
{
    public class ToDoService : IToDoService
    {
        private readonly IUnitOfWork unitOfWork;
        public ToDoService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task DeleteAsync(int id)
        {
            var toDo = await unitOfWork.ToDoRepository.FindByIdAsync(id);
            if (toDo != null)
            {
                await unitOfWork.ToDoRepository.DeleteAsync(toDo);
                await unitOfWork.CommitAsync();
            }
        }

       

        public async Task<IEnumerable<ToDoDto>> GetAllAsync()
        { return from t in await unitOfWork.ToDoRepository.ReadManyAsync() select new ToDoDto
                   {
                       Id = t.Id,
                       Content = t.Content,
                       CreatedAt = t.CreatedAt,
                       Done = t.Done
                   };
            
        }

        public async Task<ToDoDto?> GetByIdAsync(int id)
        {
            var t = await unitOfWork.ToDoRepository.FindByIdAsync(id);
            if(t != null)
            {
                return new ToDoDto
                {
                    Id = t.Id,
                    Content = t.Content,
                    CreatedAt = t.CreatedAt,
                    Done = t.Done
                };
               
            }
            return null;
        }

        public async Task NewAsync(string content)
        {
            ToDo todo = new ToDo { Content = content };
            await unitOfWork.ToDoRepository.CreateAsync(todo);
            await unitOfWork.CommitAsync();
        }

        public async Task ToggleAsync(int id)
        {
            
            var toDo = await unitOfWork.ToDoRepository.FindByIdAsync(id);
            if(toDo != null)
            {  
                toDo.Done = !toDo.Done;
                await unitOfWork.ToDoRepository.UpdateAsync(toDo);
                await unitOfWork.CommitAsync();
            }
          
        }

        public async Task UpdateAsync(int id , string content)
        {
            var toDo = await unitOfWork.ToDoRepository.FindByIdAsync(id);
            if (toDo != null)
            {
                toDo.Content = content;
                await unitOfWork.ToDoRepository.UpdateAsync(toDo);
                await unitOfWork.CommitAsync();
            }
        }
    }
}
