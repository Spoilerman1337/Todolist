using MediatR;
using System;
using TodoList.Domain.Enums;

namespace TodoList.Application.TodoItems.Commands.UpdateTodoItemDetails;

public class UpdateTodoItemDetailsCommand : IRequest
{
    public Guid Id { get; set; }
    public string Note { get; set; }
    public Priority PriorityLevel { get; set; }
}
