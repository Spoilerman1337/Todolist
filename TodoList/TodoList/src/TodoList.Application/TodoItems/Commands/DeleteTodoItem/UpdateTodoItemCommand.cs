using MediatR;
using System;

namespace TodoList.Application.TodoItems.Commands.DeleteTodoItem
{
    public class UpdateTodoItemCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid ListId { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }
}
