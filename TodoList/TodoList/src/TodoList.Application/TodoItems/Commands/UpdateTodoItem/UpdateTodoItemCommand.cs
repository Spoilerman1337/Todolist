using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Application.TodoItems.Commands.UpdateTodoItem;

public class UpdateTodoItemCommand : IRequest
{
    public Guid Id { get; set; }

    [Required]
    public string Title { get; set; }
    public bool IsDone { get; set; }
}

