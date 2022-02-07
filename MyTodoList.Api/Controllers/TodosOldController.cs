using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTodoList.Api.Core;
using MyTodoList.Api.Models;
using MyTodoList.Api.Views.Todo;
using MyTodoList.Api.Services;

namespace MyTodoList.Api.Controllers;

[ApiController]
[Route("[Controller]")]
public class TodosOldController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TodosOldController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TodoReadDto>> GetById([FromRoute] string id)
    {
        var todo = await _context.Todos.FirstOrDefaultAsync(todo => todo.Id == id);

        if (todo == null)
        {
            return NotFound("Todo not found");
        }

        return Ok(new TodoReadDto
        {
            Id = todo.Id,
            CreationDateTime = todo.CreationDateTime,
            Name = todo.Name,
            Description = todo.Description,
            IsDone = todo.IsDone,
            StartDateTime = todo.StartDateTime,
            EndDateTime = todo.EndDateTime
        });
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<TodoReadDto>>> GetAll()
    {
        var todosFromDb = await _context.Todos.ToListAsync();
        var todos = todosFromDb.Select(todo => new TodoReadDto
        {
            Id = todo.Id,
            CreationDateTime = todo.CreationDateTime,
            Name = todo.Name,
            Description = todo.Description,
            IsDone = todo.IsDone,
            StartDateTime = todo.StartDateTime,
            EndDateTime = todo.EndDateTime
        }).ToList();

        return Ok(todos);

        // foreach (var todo in todos)
        // {
        //     var todoReadDto = new TodoReadDto
        //     {
        //         Id = todo.Id,
        //         CreationDateTime = todo.CreationDateTime,
        //         Name = todo.Name,
        //         Description = todo.Description,
        //         IsDone = todo.IsDone,
        //         StartDateTime = todo.StartDateTime,
        //         EndDateTime = todo.EndDateTime
        //     };
        //     todoReadDtoList.Add(todoReadDto);
        // }
    }

    [HttpPost]
    public async Task<ActionResult<TodoReadDto>> Create([FromBody] CreateTodoRequestDto createTodoRequestDto)
    {
        var todo = new Todo
        {
            Id = Guid.NewGuid().ToString(),
            CreationDateTime = DateTime.Now,
            Name = createTodoRequestDto.Name,
            Description = createTodoRequestDto.Description,
            IsDone = false,
            StartDateTime = createTodoRequestDto.StartDateTime,
            EndDateTime = createTodoRequestDto.EndDateTime
        };

        await _context.Todos.AddAsync(todo);
        await _context.SaveChangesAsync();

        var todoReadDto = new TodoReadDto
        {
            Id = todo.Id,
            CreationDateTime = todo.CreationDateTime,
            Name = todo.Name,
            Description = todo.Description,
            IsDone = todo.IsDone,
            StartDateTime = todo.StartDateTime,
            EndDateTime = todo.EndDateTime
        };
        return Created("", todoReadDto);
    }
}
