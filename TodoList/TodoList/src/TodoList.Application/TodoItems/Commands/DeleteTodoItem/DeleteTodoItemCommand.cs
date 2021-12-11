using MediatR;
using System;

namespace TodoList.Application.TodoItems.Commands.DeleteTodoItem
{
    public class DeleteTodoItemCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
