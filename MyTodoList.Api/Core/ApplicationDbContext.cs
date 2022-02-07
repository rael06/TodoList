using Microsoft.EntityFrameworkCore;
using MyTodoList.Api.Models;

namespace MyTodoList.Api.Core;

public class ApplicationDbContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}
