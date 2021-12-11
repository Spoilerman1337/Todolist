using MediatR;
using System;

namespace TodoList.Application.TodoItems.CreateTodoItem.Commands
{
    public class CreateTodoItemCommand : IRequest<Guid>
    {
        public Guid ListId { get; set; }
        public string Title { get; set; }
    }
}
