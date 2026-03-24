using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoListApp.BusinessLogic.Dtos;
using ToDoListApp.BusinessLogic.Service;

namespace ToDoListApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IToDoService toDoService;

        public IEnumerable<ToDoDto> ToDos { get; set; } = [];

        // ? SelectedToDo eklendi
        public ToDoDto SelectedToDo { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IToDoService toDoService)
        {
            _logger = logger;
            this.toDoService = toDoService;
        }

        // ? OnGetAsync - id parametresi eklendi
        public async Task OnGetAsync(int? id)
        {
            ToDos = await toDoService.GetAllAsync();

            // Edit için seçili ToDo'yu yükle
            if (id.HasValue)
            {
                SelectedToDo = await toDoService.GetByIdAsync(id.Value);
            }
        }

        // ? OnGetEditAsync silindi - artýk OnGetAsync içinde

        // Add ToDo
        public async Task<IActionResult> OnPostAsync(string Content)
        {
            if (!string.IsNullOrWhiteSpace(Content))
            {
                await toDoService.NewAsync(Content);
            }
            return RedirectToPage("./Index");
        }

        // Edit ToDo
        public async Task<IActionResult> OnPostEditAsync(int id, string Content)
        {
            if (!string.IsNullOrWhiteSpace(Content))
            {
                await toDoService.UpdateAsync(id, Content);
            }
            return RedirectToPage("./Index");
        }

        // Toggle Done
        public async Task<IActionResult> OnPostToggleDoneAsync(int id)
        {
            await toDoService.ToggleAsync(id);
            return RedirectToPage("./Index");
        }

        // Delete ToDo
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await toDoService.DeleteAsync(id);
            return RedirectToPage("./Index");
        }
    }
}