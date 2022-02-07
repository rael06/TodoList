namespace MyTodoList.Api.Models;

public class Todo
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime CreationDateTime { get; set; }
    public bool IsDone { get; set; }
}
