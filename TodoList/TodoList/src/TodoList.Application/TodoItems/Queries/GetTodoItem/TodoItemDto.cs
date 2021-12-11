using System;
using TodoList.Application.Common.Mappings;
using TodoList.Domain.Entities;

namespace TodoList.Application.TodoItems.Queries.GetTodoItem
{
    public class TodoItemDto : IMapFrom<TodoItem>
    {
        public Guid Id { get; set; }
        public Guid ListId { get; set; }
        public string Title { get; set; }    
        public bool IsDone { get; set; }
    }
}
