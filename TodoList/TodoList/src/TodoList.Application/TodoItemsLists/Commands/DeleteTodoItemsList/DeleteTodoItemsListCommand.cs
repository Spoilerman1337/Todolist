using MediatR;
using System;

namespace TodoList.Application.TodoItemsLists.Commands.DeleteTodoItemsList
{
    public class DeleteTodoItemsListCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
