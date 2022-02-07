using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTodoList.Api.Exceptions;
using MyTodoList.Api.Services;
using MyTodoList.Api.Views.Todo;
using MyTodoList.Api.Core;

namespace MyTodoList.Api.Controllers;

[ApiController]
[Route("[Controller]")]
public class TodosController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodosController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TodoReadDto>> GetById([FromRoute] string id)
    {
        try
        {
            var todo = await _todoService.GetById(id);
            return Ok(todo);
        }
        catch (NotFoundException)
        {
            return NotFound("Todo not found");
        }
        catch (Exception)
        {
            return BadRequest("Please, retry later");
        }
    }
}
