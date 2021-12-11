using MediatR;
using System;

namespace TodoList.Application.TodoItems.Commands.UpdateTodoItem
{
    public class UpdateTodoItemsCommand : IRequest<>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }
}
