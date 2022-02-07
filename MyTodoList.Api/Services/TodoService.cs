using Microsoft.EntityFrameworkCore;
using MyTodoList.Api.Repositories;
using MyTodoList.Api.Views.Todo;
using MyTodoList.Api.Core;
using MyTodoList.Api.Exceptions;

namespace MyTodoList.Api.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;

    public TodoService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<TodoReadDto> GetById(string id)
    {
        var todo = await _todoRepository.GetById(id);

        return new TodoReadDto
        {
            Id = todo.Id,
            CreationDateTime = todo.CreationDateTime,
            Name = todo.Name,
            Description = todo.Description,
            IsDone = todo.IsDone,
            StartDateTime = todo.StartDateTime,
            EndDateTime = todo.EndDateTime
        };
    }
}
