using MediatR;
using System;

namespace TodoList.Application.TodoItemsLists.Commands.CreateTodoItemsList
{
    public class CreateTodoItemsListCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
