using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Application.TodoItems.Commands.CreateTodoItem;

public class CreateTodoItemCommand : IRequest<Guid>
{
    public Guid ListId { get; set; }

    [Required]
    public string Title { get; set; }
}

