using MediatR;
using System;
using System.Collections.Generic;

namespace TodoList.Application.TodoItems.Queries
{
    public class GetTodoItemsQuery : IRequest<List<TodoItemDto>>
    {
        public Guid ListId { get; set; }
    }
}
