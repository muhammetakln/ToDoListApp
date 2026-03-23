using ToDoListApp.BusinessLogic.Dtos;
using ToDoListApp.Data;

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
            }
        }


        public async Task<IEnumerable<ToDoDto>> GetAll()
        {
            return from t in await unitOfWork.ToDoRepository.ReadManyAsync() select new ToDoDto
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

        public Task NewAsync(string content)
        {
            throw new NotImplementedException();
        }

        public Task ToggleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(string content)
        {
            throw new NotImplementedException();
        }
    }
}
