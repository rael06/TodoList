using Microsoft.EntityFrameworkCore;
using MyTodoList.Api.Core;
using MyTodoList.Api.Exceptions;
using MyTodoList.Api.Models;

namespace MyTodoList.Api.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public TodoRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Todo> GetById(string id)
    {
        var todo = await _applicationDbContext.Todos.FirstOrDefaultAsync(x => x.Id == id);

        if (todo == null)
        {
            throw new NotFoundException();
        }

        return todo;
    }
}
