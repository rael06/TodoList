using System.ComponentModel.DataAnnotations;

namespace MyTodoList.Api.Views.Todo;

public class CreateTodoRequestDto
{
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    [Required]
    public DateTime StartDateTime { get; set; }
    [Required]
    public DateTime EndDateTime { get; set; }
}
