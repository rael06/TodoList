using MyTodoList.Api.Views.Todo;

namespace MyTodoList.Api.Services;

public interface ITodoService
{
    Task<TodoReadDto> GetById(string id);
}
