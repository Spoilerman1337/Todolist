using MediatR;
using System;

namespace TodoList.Application.TodoItemsLists.Commands.UpdateTodoItemsList
{
    public class UpdateTodoItemsListCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
