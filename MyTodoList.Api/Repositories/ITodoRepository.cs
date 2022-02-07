using MyTodoList.Api.Models;

namespace MyTodoList.Api.Repositories;

public interface ITodoRepository
{
    Task<Todo> GetById(string id);
}
